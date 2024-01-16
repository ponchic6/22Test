using System.Collections.Generic;
using UnityEngine;

public interface ILevelFruitCreator
{
    public Dictionary<Vector3Int, FruitCollider> GetFruitDictionary();
    public void InitializeFruits();
}