using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float offsetX = 50f; 
    [SerializeField] private float offsetY = 40f;

    public Transform CameraTransform;
     
    private void FixedUpdate()
    {
        CameraTransform.position = transform.position + new Vector3(offsetX, offsetY, 0);
    }
}
