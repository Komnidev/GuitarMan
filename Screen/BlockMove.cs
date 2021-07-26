using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    void FixedUpdate()
    {
        MovingDown();
    }
    private void MovingDown()
    {
        transform.position -=
            new Vector3(0, Time.deltaTime * _movementSpeed, 0);
    }
}
