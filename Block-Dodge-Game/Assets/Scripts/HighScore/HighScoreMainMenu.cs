using UnityEngine;
using UnityEngine.UI;

public class HighScoreMainMenu : MonoBehaviour {

    void Update ()
    {
        gameObject.GetComponent<Text>().text = string.Format("{0:00.00}", GameManager.manager.highScore);
    }
}
