using System.Collections.Generic;
using UnityEngine;

public interface ILevelFruitCreator
{
    public Dictionary<Vector3Int, FruitCollidDetector> GetFruitDictionary();
    public void InitializeFruits();
}