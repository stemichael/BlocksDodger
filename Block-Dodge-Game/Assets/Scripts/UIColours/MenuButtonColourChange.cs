using UnityEngine;
using UnityEngine.UI;

public class MenuButtonColourChange : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject background;

    private Button btn;
    private Image img;
    private ColorBlock cb;

    void Start()
    {
        btn = GetComponent<Button>();
        img = background.GetComponent<Image>();
        cb = btn.colors;
    }

    void Update()
    {
        if (cb.normalColor != img.color)
        {
            cb.normalColor = img.color;
            cb.highlightedColor = img.color;
            cb.disabledColor = img.color;
            cb.pressedColor = mainCamera.backgroundColor;
            btn.colors = cb;
        }
    }
}
