using System.Collections.Generic;
using UnityEngine;

public class LevelFruitCreator : ILevelFruitCreator
{
    private readonly IFruitFactory _fruitFactory;

    private Dictionary<Vector3Int, FruitCollidDetector> _fruitDictionary = new Dictionary<Vector3Int, FruitCollidDetector>();

    public LevelFruitCreator(IFruitFactory fruitFactory)
    {
        _fruitFactory = fruitFactory;
    }

    public Dictionary<Vector3Int, FruitCollidDetector> GetFruitDictionary()
    {
        return _fruitDictionary;
    }

    public void InitializeFruits()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3Int vector3Int = new Vector3Int(2 + 2 * i, 0, 2 + 2 * i);
            FruitCollidDetector fruit = _fruitFactory.CreateFruit(vector3Int);
            _fruitDictionary.Add(vector3Int, fruit);
        }
    }
}