using UnityEngine;

[RequireComponent(typeof(BlockBorderCheck))]
public class MovingBlock : MonoBehaviour
{
    private Vector3 _spawnPoint;
    private GameObject _movingBlock;

    public void SetBlock(GameObject movingblock)
    {
        _movingBlock = movingblock;
    }
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
    public void SetLayer(int layer)
    {
        _movingBlock.layer = layer;
    }
    public void SetParent(Transform parent)
    {
        _movingBlock.transform.SetParent(parent);
    }
    public void SetBorderX(float borderX)
    {
        _movingBlock.GetComponent<BlockBorderCheck>().SetBorder(borderX);
    }
    public void SetPosition()
    {
        _movingBlock.transform.localPosition = _spawnPoint;
    }
}

