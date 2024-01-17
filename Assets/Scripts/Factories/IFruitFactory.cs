using UnityEngine;

public interface IFruitFactory
{
    public FruitCollidDetector CreateFruit(Vector3Int vector);
}