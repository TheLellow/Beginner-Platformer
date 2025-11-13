using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // Drag the Player object here in the Inspector
    public float smoothSpeed = 0.125f;  // How smoothly the camera follows
    public Vector3 offset;        // Optional offset (like pulling the camera back a bit)

    void LateUpdate()
    {
        if (player == null) return;

        // Target position is the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move from current to target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update camera position
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
