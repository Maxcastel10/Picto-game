using UnityEngine;

public class TimerStopTrigger : MonoBehaviour
{
    public GameObject targetObject; // Assign the specific object (e.g., Player) in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject) // Check for the exact object, not just the tag
        {
            FindObjectOfType<LevelTimer>().StopAndSaveTime();
        }
    }
}
