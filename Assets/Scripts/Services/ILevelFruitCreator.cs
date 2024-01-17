using System.Collections.Generic;
using Monobehavior;
using UnityEngine;

namespace Services
{
    public interface ILevelFruitCreator
    {
        public Dictionary<Vector3Int, IFruitCollidDetector> GetFruitDictionary();
        public void InitializeFruitsOnLevel();
        public void ClearDictionary();
    }
}