using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : UnitBase
{
    private void Awake() 
    {
        _unitFaction = EUnitFaction.Enemy;     
    }
    public override void BulletHit(Bullet HitBullet)
    {
        switch (HitBullet.BulletSource)
        {
            case Bullet.EBulletSource.Player:
                GameManager.Instance.PlayerScore += 100;
                // GameManager.Instance.EnemyDestroyCount -= 1;
                GameManager.Instance.EnemyDestroyCount = GameManager.Instance.EnemyDestroyCount <= 0 ? 0 : GameManager.Instance.EnemyDestroyCount - 1;
                break;

            case Bullet.EBulletSource.Enemy:
                return;

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
                break;

            case EUnitFaction.Enemy:
                return;

            case EUnitFaction.Ally:
                break;

            default:
                throw new System.Exception("Unit Faction: " + CollidedUnit.UnitFaction.ToString());
        }

        Death();
    }

    protected override void Death()
    {
        print("Death: " + gameObject.name);
        Destroy(gameObject);
    }
}
