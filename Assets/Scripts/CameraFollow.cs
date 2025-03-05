using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character; // Referencia al personaje
    public Vector3 cameraOffset = new Vector3(0, 10, -10); // Offset de la cámara
    public float smoothSpeed = 5f; // Velocidad de seguimiento

    void LateUpdate()
    {
        FollowCharacter();
    }

    void FollowCharacter()
    {
        Vector3 desiredPosition = character.position + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
    }
}

