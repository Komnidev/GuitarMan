using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandDestroy : MonoBehaviour
{
    private GameObject _hand;
    public void DestroyHand(GameObject hand)
    {
        _hand = hand;
        Invoke(nameof(Destroy), 1.5f);
    }
    private void Destroy()
    {
        Destroy(_hand);
    }
}
