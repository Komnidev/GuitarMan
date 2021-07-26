using UnityEngine;

public class IdleBlock : MonoBehaviour
{
    private Vector3 _spawnPoint;
    private GameObject _idleBlock;

    public void SetBlock(GameObject idleBlock)
    {
        _idleBlock = idleBlock;
    }
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
    public void SetParent(Transform parent)
    {
        _idleBlock.transform.SetParent(parent);
    }
    public void SetLayer(int layer)
    {
        _idleBlock.layer = layer;
    }
    public void SetPosition()
    {
        _idleBlock.transform.localPosition = _spawnPoint;
    }
}
