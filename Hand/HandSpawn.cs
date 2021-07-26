using System;
using UnityEngine;

public class HandSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _hand;
    [SerializeField] private float _secondsToSpawn;
    [SerializeField] private float _xAngle;

    private float _counter;
    private System.Random _random = new System.Random(Environment.TickCount);

    private void OnEnable()
    {
        _counter = _secondsToSpawn;
    }
    private void Update()
    {
        TimerTick();
    }
    private void TimerTick()
    {
        _counter -= Time.deltaTime;
        if (_counter <= 0)
        {
            SpawnHand();
            _counter = _secondsToSpawn;
        }
    }
    private void SpawnHand()
    {
        int selected = _random.Next(_spawnPoints.Length);
        float yAngle = CalculateAngle(_spawnPoints[selected].position);

        if (_spawnPoints[selected].position.z > transform.position.z)
        {
            yAngle += 180;
        }
        else
        {
            yAngle *= -1;
        }

        Quaternion quaternion = Quaternion.Euler(_xAngle, yAngle, 0);
        GameObject hand = Instantiate(_hand, _spawnPoints[selected].position, quaternion);
        hand.GetComponent<HandMove>().Target = transform;
    }
    private float CalculateAngle(Vector3 spawnPoint)
    {
        float cathetusA = Mathf.Abs(spawnPoint.x - transform.position.x);
        float cathetusB = Mathf.Abs(spawnPoint.z - transform.position.z);
        float hypotenuse = Mathf.Sqrt(Mathf.Pow(cathetusA, 2) + Mathf.Pow(cathetusB, 2));
        float sinAlpha = cathetusA / hypotenuse;
        float angleRad = Mathf.Asin(sinAlpha);
        float yAngle = angleRad * 180 / Mathf.PI;
        return yAngle;
    }
}
