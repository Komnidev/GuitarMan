using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedUp;
    public Transform Target;

    private Vector3 _step;
    private float _direction = 1;
    public void ChangeDirection()
    {
        _direction *= -1;
        CalculateStep();
    }
    public void SpeedUp()
    {
        _speed *= _speedUp;
        CalculateStep();
    }
    private void Start()
    {
        CalculateStep();
    }
    private void CalculateStep()
    {
        Vector3 step = (Target.position - transform.position) * _speed * _direction;
        _step = new Vector3(step.x, 0, step.z);
    }
    private void FixedUpdate()
    {
        transform.position += _step;
    }
}
