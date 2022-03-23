using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource Wining;
    [SerializeField] private AudioSource Death;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerUnit _activePlayerUnit;
    public PlayerUnit ActivePlayerUnit
    {
        get
        {
            return _activePlayerUnit;
        }
        set
        {
            _activePlayerUnit = value;
        }
    }

    public PlayerUnit PlayerPrefab;
    public float PlayerSpeed = 5f;

    public int PlayerLife = 5;
    public float PlayerScore = 0f;

    public int EnemyDestroyCount = 5;

    public bool canShoot = true;

    public float VerticalSpawnEdge;
    public float HorizontalSpawnEdge;

    private bool gameWon = false;
    
    void Awake() 
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        _instance = this;
        DontDestroyOnLoad(gameObject);
        bgm.Play();
    }

    public void ResetGame()
    {
        PlayerLife = 4;
        PlayerScore = 0;
        EnemyDestroyCount = 5;
        PlayerSpeed = 5;
        gameWon = false;

        SceneManager.LoadScene("GameScene");

        bgm.Play();
    }


    public void QueueRespawn()
    {
        DeathSequence();
        StartCoroutine(DelayRespawn());
    }
    public IEnumerator DelayRespawn()
    {
        //Debug.Log("Before Respawn Yield: " +Time.time);
        yield return new WaitForSeconds(5);
        //Debug.Log("After Respawn Yield: "+Time.time);
        RespawnPlayer();
    }

    public void DeathSequence(){
        CameraShake cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        StartCoroutine(cameraShake.Shake(.15f, 1f));
        if(PlayerLife <= 0){
            bgm.Stop();
            Death.Play();
        }
        pauseGame();
    }

    private void RespawnPlayer()
    {
        resumeGame();
        if(PlayerLife > 0)
        {
            PlayerUnit player = Instantiate(PlayerPrefab, default, Quaternion.identity);
            PlayerAnimUpdater playerAnim = player.GetComponent<PlayerAnimUpdater>();
            playerAnim.inputmanager = gameObject.GetComponent<InputManager>();
        }

        if(PlayerLife <= 0)
        {
            PlayerLife = 0;
            ResetGame();
            PlayerUnit player = Instantiate(PlayerPrefab, default, Quaternion.identity);
            PlayerAnimUpdater playerAnim = player.GetComponent<PlayerAnimUpdater>();
            playerAnim.inputmanager = gameObject.GetComponent<InputManager>();
        }
    }

    public void QueueVictory()
    {
        if(gameWon)
        {
            return;
        }
        gameWon = true;
        StartCoroutine(DelayVictory());
    }

    public IEnumerator DelayVictory()
    {
        Debug.Log("Victory");
        bgm.Stop();
        Wining.Play();
        pauseGame();
        yield return new WaitForSeconds(2);
        Victory();
    }

    private void pauseGame(){
        gameObject.GetComponent<InputManager>().enabled = false;
        canShoot = false;
    }

    private void resumeGame(){
        gameObject.GetComponent<InputManager>().enabled = true;
        canShoot = true;
    }

    public void Victory()
    {
        SceneManager.LoadScene("EndScene");
    }
}
