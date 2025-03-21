using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI currentTimerText1, currentTimerText2;
    public TextMeshProUGUI bestTimeText1, bestTimeText2;
    public Transform player; // Player object
    public Transform finishObject; // Object whose X position is used to stop the timer

    private float currentTime;
    private bool isRunning = true;
    private string bestTimeKey;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        bestTimeKey = sceneName + "_BestTime";

        currentTime = 0f;
        UpdateBestTimeUI();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            string formattedTime = FormatTime(currentTime);
            currentTimerText1.text = formattedTime;
            currentTimerText2.text = formattedTime;

            // Stop timer when the player's X position is greater than or equal to the finishObject's X position
            if (player != null && finishObject != null && player.position.x >= finishObject.position.x)
            {
                StopAndSaveTime();
            }
        }
    }

    public void StopAndSaveTime()
    {
        if (!isRunning) return; // Prevent multiple stops

        isRunning = false;
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, float.MaxValue);

        if (currentTime < bestTime)
        {
            PlayerPrefs.SetFloat(bestTimeKey, currentTime);
            PlayerPrefs.Save();
        }

        UpdateBestTimeUI();
    }

    private void UpdateBestTimeUI()
    {
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, float.MaxValue);
        string bestTimeText = (bestTime == float.MaxValue) ? "--:--" : FormatTime(bestTime);
        bestTimeText1.text = bestTimeText;
        bestTimeText2.text = bestTimeText;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
