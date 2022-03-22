using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum EBulletSource
    {Player, Enemy, Ally}

    public GameObject HitEffect;
    public float damage;
    
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
        // GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Destroy(gameObject);
        FindObjectOfType<Health>().doDamage(damage);
    }
}
