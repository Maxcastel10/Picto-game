using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    
    public Slider bgMusicSlider;
    public Slider sfxSlider;
    
    public AudioSource bgMusicSource; // Assign Background Music AudioSource
    public AudioSource sfxSource; // Assign SFX AudioSource

    private bool isPaused = false;

    void Start()
    {
        pauseMenuCanvas.SetActive(false); // Hide pause menu at start
        
        // Initialize slider values with current audio levels
        if (bgMusicSource != null)
            bgMusicSlider.value = bgMusicSource.volume;

        if (sfxSource != null)
            sfxSlider.value = sfxSource.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Press Escape to pause/unpause
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause game time
        pauseMenuCanvas.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume game time
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure time is resumed before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Resume time before switching scenes
        SceneManager.LoadScene("MAIN MENU"); // Load Main Menu scene
    }

    public void AdjustBGVolume()
    {
        if (bgMusicSource != null)
            bgMusicSource.volume = bgMusicSlider.value; // Change background music volume
    }

    public void AdjustSFXVolume()
    {
        if (sfxSource != null)
            sfxSource.volume = sfxSlider.value; // Change SFX volume
    }
}
