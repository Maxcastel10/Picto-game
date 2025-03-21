using UnityEngine;
using UnityEngine.UI;

public class BGMusicController : MonoBehaviour
{
    public AudioSource bgMusic; // Reference to the AudioSource playing background music
    public Slider volumeSlider; // Reference to the UI Slider

    private const string VolumePrefKey = "BGMusicVolume"; // Key for saving volume in PlayerPrefs

    void Start()
    {
        // Load saved volume or set to default (1.0)
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1.0f);
        bgMusic.volume = savedVolume;

        // Set slider value if it exists
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    // Update volume based on slider value
    public void SetVolume(float volume)
    {
        bgMusic.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();
    }
}
