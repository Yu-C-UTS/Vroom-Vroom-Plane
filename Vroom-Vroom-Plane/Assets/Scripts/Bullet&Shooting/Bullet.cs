using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum EBulletSource
    {Player, Enemy, Ally}

    public GameObject HitEffect;

    //public float damage;
    
    [SerializeField]
    private EBulletSource _bulletSource;


    public EBulletSource BulletSource
    {
        get
        {
            return _bulletSource;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        UnitBase CollidedUnit = other.gameObject.GetComponent<UnitBase>();

        //Collided with something that is not a unit(plane), ignoring collision
        if(CollidedUnit == null)
        {
            return;
        }

        HitUnit(CollidedUnit);

        /*
        // GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Destroy(gameObject);
        if(other.gameObject.tag == "Enemy" )
        {
            FindObjectOfType<ScoreBoard>().KillEnemy();
            Debug.Log("Enemy Hit!");
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit!");
            Destroy(other.gameObject);
        }
        Destroy(other.gameObject);
        Debug.Log("Something is hit!");
        //FindObjectOfType<Health>().doDamage(damage);
        */
    }

    private void HitUnit(UnitBase otherUnit)
    {
        // GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);

        otherUnit.BulletHit(this);

        Destroy(gameObject);
    }
}
