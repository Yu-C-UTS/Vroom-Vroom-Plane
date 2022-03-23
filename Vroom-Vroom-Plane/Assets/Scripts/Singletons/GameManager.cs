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

    public PlayerUnit PlayerPrefab;
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

    public void QueueRespawn()
    {
        StartCoroutine(DelayRespawn());
    }
    public IEnumerator DelayRespawn()
    {
        Debug.Log("Before Respawn Yield: " +Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log("After Respawn Yield: "+Time.time);
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        if(PlayerLife > 0)
        {
            PlayerUnit player = Instantiate(PlayerPrefab, default, Quaternion.identity);
            PlayerAnimUpdater playerAnim = player.GetComponent<PlayerAnimUpdater>();
            playerAnim.inputmanager = gameObject.GetComponent<InputManager>();
        }

        if(PlayerLife == 0)
        {
            ResetGame();
            PlayerUnit player = Instantiate(PlayerPrefab, default, Quaternion.identity);
            PlayerAnimUpdater playerAnim = player.GetComponent<PlayerAnimUpdater>();
            playerAnim.inputmanager = gameObject.GetComponent<InputManager>();
        }
    }
}
