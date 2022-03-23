using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
        SceneManager.LoadScene("GameScene");
    }
}
