using System.Collections.Generic;
using UnityEngine;

public class LevelFruitCreator : ILevelFruitCreator
{
    private readonly IFruitFactory _fruitFactory;

    private Dictionary<Vector3Int, FruitCollider> _fruitDictionary = new Dictionary<Vector3Int, FruitCollider>();

    public LevelFruitCreator(IFruitFactory fruitFactory)
    {
        _fruitFactory = fruitFactory;
    }

    public Dictionary<Vector3Int, FruitCollider> GetFruitDictionary()
    {
        return _fruitDictionary;
    }

    public void InitializeFruits()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3Int vector3Int = new Vector3Int(1 + 2 * i, 0, 1 + 2 * i);
            FruitCollider fruit = _fruitFactory.CreateFruit(vector3Int);
            _fruitDictionary.Add(vector3Int, fruit);
        }
    }
}