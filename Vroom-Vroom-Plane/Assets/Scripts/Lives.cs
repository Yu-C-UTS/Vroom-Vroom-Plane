using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Text liveText;
    // Start is called before the first frame update
    void Start()
    {
        liveText = GameObject.Find("liveText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLive(GameManager.Instance.PlayerLife);
    }

        void DisplayLive(int liveToDisplay)
    {
        liveText.text = liveToDisplay.ToString();
    }
}
