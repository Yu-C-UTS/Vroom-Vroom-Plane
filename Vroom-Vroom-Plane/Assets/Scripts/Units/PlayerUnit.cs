using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitBase
{
    [SerializeField] private AudioSource hitSfx;

    private int isInvincible = 0;

    private void Awake() 
    {
        GetComponent<PlayerAnimUpdater>().inputmanager = InputManager.Instance;
        _unitFaction = EUnitFaction.Player;     
    }

    private void Start() 
    {
        GameManager.Instance.ActivePlayerUnit = this;    
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
        if(isInvincible != 0)
        {
            return;
        }
        
        GameManager.Instance.PlayerLife -= 1;
        GameManager.Instance.QueueRespawn();
        print("Death: " + gameObject.name);
        //hitSfx.Play();
        Destroy(gameObject);
    }

    public void PowerUpDoubleSpeed()
    {
        GameManager.Instance.PlayerSpeed *= 2;
        DelaySpeedReset();
    }

    private IEnumerator DelaySpeedReset()
    {
        yield return new WaitForSeconds(20);
        GameManager.Instance.PlayerSpeed /= 2;
    }

    public void PowerUpDoubleFire()
    {
        GetComponent<Shooting>().barrageFireCount *= 2;
        DelayFireCountReset();
    }

    private IEnumerator DelayFireCountReset()
    {
        yield return new WaitForSeconds(20);
        GetComponent<Shooting>().barrageFireCount /= 2;
    }

    public void PowerUpInvincible()
    {
        isInvincible += 1;
    }

    private IEnumerator DelayInvincibilityReset()
    {
        yield return new WaitForSeconds(15);
        isInvincible -= 1;
    }
}
