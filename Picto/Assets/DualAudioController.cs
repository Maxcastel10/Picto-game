using UnityEngine;
using UnityEngine.UI;

public class DualAudioController : MonoBehaviour
{
    public AudioSource bgMusic;    // Background music source
    public AudioSource sfxSource;  // Sound effects source

    public Slider bgMusicSlider;   // Slider for background music
    public Slider sfxSlider;       // Slider for sound effects

    private const string BGVolumeKey = "BGMusicVolume";  // PlayerPrefs key for BG music
    private const string SFXVolumeKey = "SFXVolume";     // PlayerPrefs key for SFX

    void Start()
    {
        // Load saved volumes or set default (1.0)
        float bgVolume = PlayerPrefs.GetFloat(BGVolumeKey, 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1.0f);

        bgMusic.volume = bgVolume;
        sfxSource.volume = sfxVolume;

        // Assign values to sliders if available
        if (bgMusicSlider != null)
        {
            bgMusicSlider.value = bgVolume;
            bgMusicSlider.onValueChanged.AddListener(SetBGVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    // 🎵 Set and save background music volume
    public void SetBGVolume(float volume)
    {
        bgMusic.volume = volume;
        PlayerPrefs.SetFloat(BGVolumeKey, volume);
        PlayerPrefs.Save();
    }

    // 🔊 Set and save sound effects volume
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
