using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyUnit : EnemyUnit
{
    public override void BulletHit(Bullet HitBullet)
    {
        switch (HitBullet.BulletSource)
        {
            case Bullet.EBulletSource.Player:
                GameManager.Instance.PlayerScore += 100;
                GameManager.Instance.EnemyDestroyCount -= 1;
                GameManager.Instance.QueueVictory();
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
}
