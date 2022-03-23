using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    void Start()
    {
        totalScore = 0;
        scoreText = GameObject.Find("highScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore(totalScore);
    }

    public void KillEnemy()
    {
        totalScore += 100;
    }

    public void KillBoss()
    {
        totalScore += 400;
    }

    public void PickupParachute()
    {
        totalScore += 50;
    }

    void DisplayScore(int scoreToDisplay)
    {
        scoreText.text = scoreToDisplay.ToString();
    }
}
