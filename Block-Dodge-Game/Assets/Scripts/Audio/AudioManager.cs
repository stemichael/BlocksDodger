using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager manager;

    private float soundPitchLimit = 1.37f;
    private float soundPitchIncrease = 0.00002f;

    private AudioSource volumeMusic;
    private AudioSource volumeSFXPowerUp;
    private AudioSource volumeSFXLosing;

    void Awake()
    {
        manager = this;

        volumeMusic = GetComponent<AudioSource>();
        volumeSFXPowerUp = transform.FindChild("PowerUpSound").GetComponent<AudioSource>();
        volumeSFXLosing = transform.FindChild("LosingSound").GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("Music"))
            LoadSoundSettings();
    }

    void Start()
    {
        GetComponent<AudioSource>().pitch = 1.0f;
    }

    void Update()
    {
        if (GetComponent<AudioSource>().pitch <= soundPitchLimit && Time.timeScale == 1)
            GetComponent<AudioSource>().pitch += soundPitchIncrease;
    }

    public void PowerUpSound()
    {
        transform.FindChild("PowerUpSound").GetComponent<AudioSource>().Play();
    }

    public void EndGameSound()
    {
        transform.FindChild("LosingSound").GetComponent<AudioSource>().Play();
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat("Music", volumeMusic.volume);
        PlayerPrefs.SetFloat("SFX", volumeSFXPowerUp.volume);
    }

    public void LoadSoundSettings()
    {
        volumeMusic.volume = PlayerPrefs.GetFloat("Music");
        volumeSFXPowerUp.volume = PlayerPrefs.GetFloat("SFX");
        volumeSFXLosing.volume = PlayerPrefs.GetFloat("SFX");
    }

}
