using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UIManagerMainGame : MonoBehaviour {

    public GameObject menuButtonPanel;
    public GameObject exitPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitPanel.activeInHierarchy)
                return;

            PauseGame();
            menuButtonPanel.SetActive(false);
            exitPanel.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            Social.ReportProgress("CgkIxsmT_awEEAIQGQ", 100.0f, (bool success) => { });
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
