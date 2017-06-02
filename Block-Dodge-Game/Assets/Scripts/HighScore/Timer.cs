using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float countdown = 0f;

    public static float countdownSave = 0f;

    public Text timerText;
	
	void Update () {

        countdown += Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        countdownSave = countdown;

        if (countdown > GameManager.manager.highScore && timerText.color == Color.white)
        {
            timerText.color = new Color(0.45f, 1, 0.51f, 1);
        }

        // Achievements Start
        if (countdown >= 100f)
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQHg", 100.0f, (bool success) => { });
        }
        if (countdown >= 250f)
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQHw", 100.0f, (bool success) => { });
        }
        if (countdown >= 500f)
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQIA", 100.0f, (bool success) => { });
        }
        if (countdown >= 750f)
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQIQ", 100.0f, (bool success) => { });
        }
        if (countdown >= 1000f)
        {
            Social.ReportProgress("CgkIxsmT_awEEAIQIg", 100.0f, (bool success) => { });
        }
        // Achievements End

        timerText.text = "Time \n"  + string.Format("{0:00.00}", countdown);
    }

}
