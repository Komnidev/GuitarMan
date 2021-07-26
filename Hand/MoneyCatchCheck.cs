using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyCatchCheck : MonoBehaviour
{
    public UnityEvent<GameObject> HandCaughtTheMoney;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            HandCaughtTheMoney.Invoke(collision.gameObject);
        }
    }
}
