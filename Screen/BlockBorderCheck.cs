using UnityEngine;

public class BlockBorderCheck : MonoBehaviour
{
    private float _borderX;
    
    void FixedUpdate()
    {
        if (transform.localPosition.x <= _borderX)
            Destroy(gameObject);
    }
    public void SetBorder(float border)
    {
        _borderX = border;
    }
}
