using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitBase
{
    [SerializeField] private AudioClip hitSfx;
    private void Awake() 
    {
        GetComponent<PlayerAnimUpdater>().inputmanager = GameManager.Instance.GetComponent<InputManager>();
        _unitFaction = EUnitFaction.Player;     
    }
    public override void BulletHit(Bullet HitBullet)
    {
        switch (HitBullet.BulletSource)
        {
            case Bullet.EBulletSource.Player:
                return;

            case Bullet.EBulletSource.Enemy:
                break;

            case Bullet.EBulletSource.Ally:
                break;
            
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
                return;

            case EUnitFaction.Enemy:
                break;

            case EUnitFaction.Ally:
                break;
            
            default:
                throw new System.Exception("Unit Faction: " + CollidedUnit.UnitFaction.ToString());
        }

        Death();
    }

    protected override void Death()
    {
        GameManager.Instance.PlayerLife -= 1;
        GameManager.Instance.QueueRespawn();
        print("Death: " + gameObject.name);
        AudioSource.PlayClipAtPoint(hitSfx, transform.position);
        Destroy(gameObject);
    }
}
