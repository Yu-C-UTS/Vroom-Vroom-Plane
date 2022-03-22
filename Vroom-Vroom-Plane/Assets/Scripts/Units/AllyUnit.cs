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

    protected override void Death()
    {
        print("Death");
        Destroy(gameObject);
    }

}
