using System;
using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
    [SerializeField] private float _secondsToSpawn;
    [Tooltip("BorderX is because of local position of screen.")] 
    [SerializeField] private float _borderX;
    [SerializeField] private int _layer;
    public MyBlock[] MyBlocks;

    private float _counter;
    private System.Random _random = new System.Random(Environment.TickCount);
    private GameObject[] _instances;

    public GameObject[] GetInstanses()
    {
        return _instances;
    }
    private void OnEnable()
    {
        if (MyBlocks.Length == 0)
        {
            throw new Exception("MovingBlocks == 0");
        }

        _instances = new GameObject[MyBlocks.Length];

        for (int i = 0; i < MyBlocks.Length; i++)
        {
            MyBlock myBlock = MyBlocks[i];

            if (myBlock.IdleBlock == null)
            {
                throw new Exception($"IdleBlock {i} == null");
            }

            if (myBlock.MovingBlock == null)
            {
                throw new Exception($"MovingBlock {i} == null");
            }

            _instances[i] = Instantiate(myBlock.IdleBlock);
            IdleBlock idleBlock = _instances[i].AddComponent<IdleBlock>(); 
            idleBlock.SetBlock(_instances[i]);
            idleBlock.SetSpawnPoint(myBlock.IdleBlockSpawnPoint);
            idleBlock.SetLayer(_layer);
            idleBlock.SetParent(transform);
            idleBlock.SetPosition();
        }

        _counter = _secondsToSpawn;
    }
    private void FixedUpdate()
    {
        TimerTick();
    }
    private void TimerTick()
    {
        _counter -= Time.deltaTime;
        if (_counter <= 0)
        {
            int selected = _random.Next(MyBlocks.Length);
            GameObject movingBlockInstance = Instantiate(MyBlocks[selected].MovingBlock);
            MovingBlock movingBlock = movingBlockInstance.AddComponent<MovingBlock>();
            movingBlock.SetBlock(movingBlockInstance);
            movingBlock.SetSpawnPoint(MyBlocks[selected].MovingBlockSpawnPoint);
            movingBlock.SetLayer(_layer);
            movingBlock.SetParent(transform);
            movingBlock.SetBorderX(_borderX);
            movingBlock.SetPosition();

            _counter = _secondsToSpawn;
        }
    }
}
[Serializable]
public class MyBlock
{
    public GameObject MovingBlock;
    public Vector3 MovingBlockSpawnPoint;
    public GameObject IdleBlock;
    public Vector3 IdleBlockSpawnPoint;
    public KeyCode ControlKey;
}



