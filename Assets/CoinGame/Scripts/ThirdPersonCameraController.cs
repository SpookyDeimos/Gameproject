using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(2f, 4f, -5f); 
    public float smoothSpeed = 0.125f; 

    private Vector3 desiredPosition;

    void LateUpdate()
    {
        
        desiredPosition = target.position + offset;

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        
        transform.LookAt(target);
    }
}
