using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timeElapsed;
    public bool timerIsRunning = false;
    void Start()
    {
        timerIsRunning = true;
        timeText = GameObject.Find("timeElapsedText").GetComponent<Text>();
    }

    void Update()
    {
        DisplayTime(timeElapsed);
        timeElapsed += Time.deltaTime;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
