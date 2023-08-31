using UnityEngine;

/// <summary>
/// Controls a third-person camera that follows and looks at a target object.
/// </summary>
public class ThirdPersonCameraController : MonoBehaviour
{
    /// <summary>
    /// The target  the camera follows.
    /// </summary>
    public Transform target;

    /// <summary>
    /// The offset from the target's position where the camera should be.
    /// </summary>
    public Vector3 offset = new Vector3(2f, 4f, -5f);

    /// <summary>
    /// The smoothness transition for camera movement.
    /// </summary>
    public float smoothSpeed = 0.125f;

    private Vector3 desiredPosition;

    /// <summary>
    /// LateUpdate is called once per frame after all other updates.
    /// </summary>
    void LateUpdate()
    {
        // Calculate the desired position based on the target's position and the offset
        desiredPosition = target.position + offset;

        // Smoothly moves the camera's position towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
