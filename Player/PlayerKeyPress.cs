using System;
using UnityEngine;
using UnityEngine.Events;

class PlayerKeyPress : MonoBehaviour
{
    public GameObject Screen;

    private MyBlock[] _myBlocks;
    private KeyCode[] _keyCodes;
    private GameObject[] _idleBlocks;

    public UnityEvent<KeyCode, GameObject> BlockPressed;

    private void Start()
    {
        CreateBlocks component = Screen.GetComponent<CreateBlocks>();
        _myBlocks = component.MyBlocks;
        _keyCodes = new KeyCode[_myBlocks.Length];
        _idleBlocks = component.GetInstanses();

        for (int i = 0; i < _myBlocks.Length; i++)
        {
            _keyCodes[i] = _myBlocks[i].ControlKey;

            if (_keyCodes[i] == KeyCode.None)
            {
                throw new Exception($"_keyCodes[{i}] == none");
            }

        }
    }
    private void Update()
    {
        for (int i = 0; i < _keyCodes.Length; i++)
        {
            if (Input.GetKey(_keyCodes[i]))
            {
                BlockPressed.Invoke(_keyCodes[i], _idleBlocks[i]);
            }
        }
    }
}
[System.Serializable]
public class BlockPressed : UnityEvent<KeyCode, GameObject> { }

