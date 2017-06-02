using UnityEngine;
using GooglePlayGames;

public class Player : MonoBehaviour
{

    private float speed = 10f;
    private float mapWidth = 4.65f;

    private bool endGame = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public Sprite[] playerEmotions;



    void Start()
    {
        endGame = false;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Timer.countdownSave > GameManager.manager.highScore && sr.sprite != playerEmotions[1] && sr.sprite != playerEmotions[0])
        {
            sr.sprite = playerEmotions[1];
        }
    }

    void FixedUpdate()
    {
        float x = Input.touchCount * Time.fixedDeltaTime * speed;

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.y < (Screen.height / 4) * 3)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    Vector2 newPosition = rb.position + Vector2.right * x;
                    newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
                    rb.MovePosition(newPosition);
                    return;
                }
                else if (touch.position.x < Screen.width / 2)
                {
                    Vector2 newPosition = rb.position + Vector2.left * x;
                    newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
                    rb.MovePosition(newPosition);
                    return;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Block(Clone)" && !endGame)
        {
            endGame = true;

            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQGg", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQGw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQHA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQHQ", 1, (bool success) => { });

            AudioManager.manager.EndGameSound();
            GameManager.manager.EndGame();
            sr.sprite = playerEmotions[0];
        }

        if (coll.gameObject.name == "PowerUpClock(Clone)")
        {
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQDw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQEA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQEQ", 1, (bool success) => { });

            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQBw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCQ", 1, (bool success) => { });

            AudioManager.manager.PowerUpSound();
            Destroy(coll.gameObject);
            GetComponent<PowerUpManager>().Clock();
        }


        if (coll.gameObject.name == "PowerUpInvisible(Clone)")
        {
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQEg", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQEw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQFA", 1, (bool success) => { });

            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQBw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCQ", 1, (bool success) => { });

            AudioManager.manager.PowerUpSound();
            Destroy(coll.gameObject);
            GetComponent<PowerUpManager>().Invisible();
        }


        if (coll.gameObject.name == "PowerUpResize(Clone)")
        {
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQDA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQDQ", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQDg", 1, (bool success) => { });

            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQBw", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCA", 1, (bool success) => { });
            PlayGamesPlatform.Instance.IncrementAchievement("CgkIxsmT_awEEAIQCQ", 1, (bool success) => { });

            AudioManager.manager.PowerUpSound();
            Destroy(coll.gameObject);
            GetComponent<PowerUpManager>().Resize();
        }
    }

}
