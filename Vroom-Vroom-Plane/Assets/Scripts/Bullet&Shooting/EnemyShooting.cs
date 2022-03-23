using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float time = 0.0f; 
    public float interpolationPeriod = 1f; //Bullet Delay
    public Transform firePoint;
    public Bullet bulletPrefab;
    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         time += Time.deltaTime;
 
        if (time >= interpolationPeriod) 
        {
            time = time - interpolationPeriod;
            Shoot();
        }
    }

    void Shoot()
    {
        if(GameManager.Instance.canShoot)
        {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.BulletDirection = DirectionsUtil.RotationToDirection(bullet.transform.rotation.eulerAngles.z);
        bullet.bulletSpeed = bulletSpeed;
        // Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // rb.AddForce(firePoint.up * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet, 3f);
        }
    }
}
