using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;

public class UIManagerMainMenu : MonoBehaviour {

    public GameObject exitPanel;

    void Awake()
    {
        PlayGamesPlatform.Activate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitPanel.activeInHierarchy)
                return;

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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AchievementButton()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    public void LeaderboardButton()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            Social.ReportProgress("CgkIxsmT_awEEAIQGQ", 100.0f, (bool success) => { });
        }
    }

}
