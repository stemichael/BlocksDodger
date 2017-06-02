using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager manager;

	private float slowness = 10f;

    public float highScore = 0f;

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

        Load();
    }

    void Start()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) => {

            });
        }
    }

    public void EndGame ()
	{
        AudioManager.manager.EndGameSound();
        StartCoroutine(RestartLevel());
    }

	IEnumerator RestartLevel ()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds(1f / slowness);

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        if (Timer.countdownSave > highScore)
        {
            highScore = Timer.countdownSave;

            Social.ReportScore(Convert.ToInt32(Timer.countdownSave), "CgkIxsmT_awEEAIQAQ", (bool success) => { });

            Save();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            highScore = data.highScore;
        }
    }

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.highScore = highScore;
        
        bf.Serialize(file, data);
        file.Close();
    }

}

[Serializable]
class PlayerData
{
    public float highScore;
}
