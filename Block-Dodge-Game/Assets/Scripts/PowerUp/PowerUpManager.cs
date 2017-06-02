using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{

    private Vector3 ls;

    private float countdown = 10f;

    public Text powerUpTimerText;

    void Start()
    {
        ls = transform.localScale;
    }

    void Update()
    {
        if (powerUpTimerText.IsActive())
        {
            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown, 0f, 10f);
            powerUpTimerText.text = "PowerUp \n" + string.Format("{0:00.00}", countdown);
        }
    }

    public void Clock()
    {
        StartCoroutine(ClockEnumerator());
    }

    public void Invisible()
    {
        StartCoroutine(InvisibleEnumerator());
    }

    public void Resize()
    {
        StartCoroutine(ResizeEnumerator());
    }


    IEnumerator ClockEnumerator()
    {
        powerUpTimerText.enabled = true;

        Block.slowDown = true;

        yield return new WaitForSeconds(10f);

        Block.slowDown = false;

        powerUpTimerText.enabled = false;
        countdown = 10f;
    }

    IEnumerator InvisibleEnumerator()
    {
        powerUpTimerText.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("PlayerInvisible");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(10f);

        gameObject.layer = LayerMask.NameToLayer("Player");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.925f, 0.925f, 0.925f, 1);

        powerUpTimerText.enabled = false;
        countdown = 10f;
    }

    IEnumerator ResizeEnumerator()
    {
        powerUpTimerText.enabled = true;

        ls.x /= 2;
        transform.localScale = ls;

        yield return new WaitForSeconds(10f);

        ls.x *= 2;
        transform.localScale = ls;

        powerUpTimerText.enabled = false;
        countdown = 10f;
    }
}
