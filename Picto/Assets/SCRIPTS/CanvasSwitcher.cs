using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject mainCanvas;  // The main menu canvas
    public GameObject canvas1;  // First canvas
    public GameObject canvas2;  // Second canvas

    void Start()
    {
        // Ensure only the main canvas is active at the start
        OpenMainCanvas();
    }

    public void OpenCanvas1()
    {
        SetActiveCanvas(canvas1);
    }

    public void OpenCanvas2()
    {
        SetActiveCanvas(canvas2);
    }

    public void OpenMainCanvas()
    {
        SetActiveCanvas(mainCanvas);
    }

    private void SetActiveCanvas(GameObject canvasToOpen)
    {
        // Disable all canvases first
        mainCanvas.SetActive(false);
        canvas1.SetActive(false);
        canvas2.SetActive(false);

        // Enable the selected canvas
        canvasToOpen.SetActive(true);
    }
}
