using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRespawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public float xPosLimit = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > xPosLimit)
        {
            gameObject.transform.position = SpawnPoint.transform.position;
        }   
    }
}
