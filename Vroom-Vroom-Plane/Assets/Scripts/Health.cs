using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    public void doDamage(float damage)
    {
        currentHealth -= damage;
    }

    void HealthCheck()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
