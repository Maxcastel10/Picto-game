using UnityEngine;
using TMPro;

public class MainMenuBestTimes : MonoBehaviour
{
    public TextMeshProUGUI[] levelBestTimes; // Assign in Inspector for LEVEL1-LEVEL8

    private string[] levelNames = { "LEVEL1", "LEVEL2", "LEVEL3", "LEVEL4", "LEVEL5", "LEVEL6", "LEVEL7", "LEVEL8" };

    void Start()
    {
        for (int i = 0; i < levelNames.Length; i++)
        {
            string bestTimeKey = levelNames[i] + "_BestTime"; // Fetching saved best time
            float bestTime = PlayerPrefs.GetFloat(bestTimeKey, float.MaxValue);
            string formattedTime = (bestTime == float.MaxValue) ? "--:--" : FormatTime(bestTime);

            if (levelBestTimes[i] != null)
            {
                levelBestTimes[i].text = formattedTime; // Show time in UI
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
