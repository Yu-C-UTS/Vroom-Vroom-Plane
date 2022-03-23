using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public float PlayerSpeed = 5f;

    public int PlayerLife = 5;
    public float PlayerScore = 0f;

    public int EnemyDestroyCount = 0;

    void Awake() 
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        PlayerLife = 5;
        PlayerScore = 0;
        EnemyDestroyCount = 0;
    }

}
