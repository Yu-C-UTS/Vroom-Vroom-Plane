using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText1 = GameObject.Find("ScoreTxt").GetComponent<Text>();
        score = PlayerPrefs.GetInt("score");
        string scoreToDisplay = score.ToString();
        scoreText.text = "Score: " + scoreToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        string scoreToDisplay = score.ToString();
        scoreText.text = "Score: " + scoreToDisplay;
    }
}
