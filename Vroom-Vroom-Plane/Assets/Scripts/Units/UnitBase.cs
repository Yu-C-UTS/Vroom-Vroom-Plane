using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public virtual void BulletHit(Bullet HitBullet)
    {
        Debug.LogWarning("Bullet hit function not overwritten");
    }

    protected virtual void Death()
    {
        Debug.LogWarning("Death function not overwritten");
    }
}
