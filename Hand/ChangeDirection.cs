using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public void ChangeHandDirection(GameObject hand)
    {
        hand.TryGetComponent(out HandMove component);
        component.ChangeDirection();
        component.SpeedUp();
    }
}
