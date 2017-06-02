using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
    }

}
