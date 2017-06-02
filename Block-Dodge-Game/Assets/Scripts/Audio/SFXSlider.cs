using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.HasKey("SFX"))
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFX");
    }

}
