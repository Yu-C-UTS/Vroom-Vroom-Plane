using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaCheck : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit GameArea");
        Destroy(other.gameObject);
    }
}
