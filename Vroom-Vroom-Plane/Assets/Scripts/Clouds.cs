using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Cloud Exit! Can Shoot is True");
            GameManager.Instance.canShoot = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Cloud Enter! Can Shoot is False");
            GameManager.Instance.canShoot = false;
        }
    }


}
