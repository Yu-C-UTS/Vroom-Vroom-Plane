using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : UnitBase
{ 
    [SerializeField]
    private Parachute parachutePrefab;

    private void Awake() 
    {
        _unitFaction = EUnitFaction.Ally;     
    }

    public override void BulletHit(Bullet HitBullet)
    {
        switch (HitBullet.BulletSource)
        {
            case Bullet.EBulletSource.Player:
                GameManager.Instance.PlayerLife = 0;
                GameManager.Instance.QueueRespawn();
                break;

            case Bullet.EBulletSource.Enemy:
                break;

            case Bullet.EBulletSource.Ally:
                return;
            
            default:
                throw new System.Exception("Unknown Bullet Source");
        }

        Death();
    }

    public override void PlaneCollide(UnitBase CollidedUnit)
    {
        switch (CollidedUnit.UnitFaction)
        {
            case EUnitFaction.Player:
                break;

            case EUnitFaction.Enemy:
                break;

            case EUnitFaction.Ally:
                return;
            
            default:
                throw new System.Exception("Unit Faction: " + CollidedUnit.UnitFaction.ToString());
        }

        Death();
    }

    protected override void Death()
    {
        Parachute parachute = Instantiate(parachutePrefab, transform.position, transform.rotation);
        parachute.ParachuteDirection = GetComponentInParent<MovementBehavior>().FacingDirection;
        Destroy(gameObject);
    }

}
