using UnityEngine;
using UnityEngine.UI;


public class Block : MonoBehaviour
{

    public static bool slowDown = false;

    private float tempGravityScale = 0f;

    private float blockSpeed = 0.3f;
    private bool increaseSpeed = true;
    Vector3 barFillScaleY;

    public GameObject speedMeterFill;
    public GameObject speedMeterText;
    public Sprite[] enemyEmotions;

    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private RectTransform rt;
    private Text txt;

    void Start()
    {
        speedMeterFill = GameObject.Find("SpeedBarFill");
        speedMeterText = GameObject.Find("SpeedBarText");


        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        rt = speedMeterFill.GetComponent<RectTransform>();
        txt = speedMeterText.GetComponent<Text>();

        if (blockSpeed < 1.5f)
            blockSpeed += Time.timeSinceLevelLoad / 250f;
        else
            blockSpeed = 1.5f;
    }

    void Update()
    {

        if (slowDown)
        {
            if (rb2d.gravityScale != 0.2f)
                tempGravityScale = blockSpeed;

            rb2d.gravityScale = 0.2f;
        }
        else if (increaseSpeed)
        {
            if (blockSpeed < 1.5f)
            {
                if (tempGravityScale != 0)
                {
                    rb2d.gravityScale = tempGravityScale;
                }
                else
                {
                    rb2d.gravityScale += Time.timeSinceLevelLoad / 250f;

                    barFillScaleY = rt.localScale;
                    barFillScaleY.y += 0.00298f;
                    rt.localScale = barFillScaleY;
                }

                increaseSpeed = false;
            }
            else
            {
                rb2d.gravityScale = 1.5f;
                if (txt.text != "Speed MAXED")
                    txt.text = "Speed MAXED";
            }
        }

        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }

        if (Timer.countdownSave > GameManager.manager.highScore && sr.sprite != enemyEmotions[1] && sr.sprite != enemyEmotions[0])
        {
            sr.sprite = enemyEmotions[1];
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        sr.sprite = enemyEmotions[0];
    }

}
