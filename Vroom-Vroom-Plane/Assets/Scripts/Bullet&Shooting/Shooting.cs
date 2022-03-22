using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float time = 0.0f; 
    public float interpolationPeriod = 0.5f; //Bullet Delay
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
         if (time >= interpolationPeriod) 
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
                Destroy(bullet, 3f);
                time = 0;
            }

    }
}
