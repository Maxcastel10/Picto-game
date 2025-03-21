using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player; // Assign the player object in the Inspector
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 2f, -10f); // Adjust for desired camera position

    void LateUpdate()
    {
        if (player == null) return; // Prevent errors if player is not assigned

        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
