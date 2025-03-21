using UnityEngine;

public class ShowCanvasOnPass : MonoBehaviour
{
    public GameObject targetCanvas; // Assign the Canvas in Inspector
    public Transform player; // Assign the player GameObject in Inspector
    private bool hasTriggered = false; // Prevent multiple triggers

    void Update()
    {
        if (!hasTriggered && player.position.x > transform.position.x) // Change to y or z for different axis
        {
            ShowCanvas();
            hasTriggered = true;
        }
    }

    void ShowCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(true);
        }
    }
}
