using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public enum EUnitFaction
    {Player, Enemy, Ally}

    protected EUnitFaction _unitFaction;
    public EUnitFaction UnitFaction
    {
        get
        {
            return _unitFaction;
        }
    }

    private bool _isVisible = false;
    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }
    }

    public virtual void BulletHit(Bullet HitBullet)
    {
        Debug.LogWarning("Bullet hit function not overwritten");
    }

    public virtual void PlaneCollide(UnitBase CollidedUnit)
    {
        Debug.LogWarning("Plane collision function not overwritten");
    }

    protected virtual void Death()
    {
        Debug.LogWarning("Death function not overwritten");
    }

    private void OnBecameInvisible() 
    {
        _isVisible = false;
    }

    private void OnBecameVisible() 
    {
        _isVisible = true;    
    }
}
