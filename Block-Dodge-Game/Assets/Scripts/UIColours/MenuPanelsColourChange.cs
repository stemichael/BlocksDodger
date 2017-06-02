using UnityEngine;
using UnityEngine.UI;

public class MenuPanelsColourChange : MonoBehaviour
{

    public Camera mainCamera;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (img.color != mainCamera.backgroundColor)
        {
            img.color = mainCamera.backgroundColor;
        }
    }
}
