using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public Text liveText;
    // Start is called before the first frame update
    void Start()
    {
        liveText = GameObject.Find("liveText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLive(gameManager.PlayerLife);
    }

        void DisplayLive(int liveToDisplay)
    {
        liveText.text = liveToDisplay.ToString();
    }
}
