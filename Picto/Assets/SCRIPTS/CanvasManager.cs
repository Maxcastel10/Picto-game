using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject exitCanvas;
    public GameObject playGameCanvas; // New Play Game Canvas
    public GameObject changeControlsCanvas;
    void Start()
    {
        ShowCanvas(mainMenuCanvas); // Default to Main Menu
    }

    public void ShowCanvas(GameObject canvasToShow)
    {
        // Deactivate all canvases
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        playGameCanvas.SetActive(false); // Disable Play Game Canvas too

        // Activate only the selected canvas
        if (canvasToShow != null)
            canvasToShow.SetActive(true);
    }

    public void OpenMainMenuCanvas()
    {
        ShowCanvas(mainMenuCanvas);
    }

    public void OpenSettingsCanvas()
    {
        ShowCanvas(settingsCanvas);
    }

    public void OpenExitCanvas()
    {
        ShowCanvas(exitCanvas);
    }

    public void OpenPlayGameCanvas()
    {
        ShowCanvas(playGameCanvas); // Leads to the Play Game Canvas instead of switching scenes
    }

    public void OpenChangeControlsCanvas()
    {
        ShowCanvas(changeControlsCanvas); // Leads to the Play Game Canvas instead of switching scenes
    }

    public void ConfirmExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
        #endif
    }

    
}
