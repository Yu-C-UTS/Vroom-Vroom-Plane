using UnityEngine.UI;
using UnityEngine;

public class EnemyRemainingCount : MonoBehaviour
{
    public Text remainingText;
    // Start is called before the first frame update
    void Start()
    {
        remainingText = GameObject.Find("enemyCountText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayEnemyCount(GameManager.Instance.EnemyDestroyCount);
        if(GameManager.Instance.EnemyDestroyCount <= 0)
        {
            //GameManager.Instance.QueueVictory();
        }
    }

        void DisplayEnemyCount(int countToDisplay)
    {
        remainingText.text = countToDisplay.ToString();
    }
}
