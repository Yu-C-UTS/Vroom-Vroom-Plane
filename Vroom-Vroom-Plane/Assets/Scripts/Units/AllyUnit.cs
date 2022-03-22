using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : UnitBase
{

    public override void BulletHit(Bullet HitBullet)
    {
        switch (HitBullet.BulletSource)
        {
            case Bullet.EBulletSource.Player:
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
        print("Death: " + gameObject.name);
        Destroy(gameObject);
    }

}
