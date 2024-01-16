using UnityEngine;

public interface IFruitFactory
{
    public FruitCollider CreateFruit(Vector3Int vector);
}