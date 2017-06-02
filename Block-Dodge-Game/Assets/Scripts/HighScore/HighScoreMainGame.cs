using UnityEngine;
using UnityEngine.UI;

public class HighScoreMainGame : MonoBehaviour {

    public Text highScoreText;

    void Update ()
    {
        highScoreText.text = "High \n Score \n" + string.Format("{0:00.00}", GameManager.manager.highScore);
    }
}
