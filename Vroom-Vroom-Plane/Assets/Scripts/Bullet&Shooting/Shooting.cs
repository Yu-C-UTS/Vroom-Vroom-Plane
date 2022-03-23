using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float fireCooldown; 
    public float interpolationPeriod = 3f; //Bullet Delay
    public Transform firePoint;
    public Bullet bulletPrefab;
    public float bulletSpeed = 20f;

    [SerializeField]
    private float barrageFireDelay = 0.5f;
    [SerializeField]
    private int barrageFireCount = 2;
    private float barrageFireCooldown;
    private int remainingBarrageCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCheck();
        }

        if(remainingBarrageCount > 0)
        {
            barrageFireCooldown -= Time.deltaTime;
            if(barrageFireCooldown <= 0)
            {
                Fire();
                barrageFireCooldown += barrageFireDelay;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.ResetGame();
        }
    }

    void FireCheck()
    {
        if (fireCooldown <= 0) 
        {
            barrageFireCooldown = 0;
            remainingBarrageCount = barrageFireCount;
            fireCooldown = interpolationPeriod;
        }
    }

    private void Fire()
    {
        remainingBarrageCount -= 1;

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.BulletDirection = DirectionsUtil.RotationToDirection(bullet.transform.rotation.eulerAngles.z);
        bullet.bulletSpeed = bulletSpeed;
        // Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // rb.AddForce(firePoint.up * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet, 3f);
    }
}
