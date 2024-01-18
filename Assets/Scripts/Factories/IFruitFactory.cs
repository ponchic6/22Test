using Enums;
using Monobehavior;
using UnityEngine;

namespace Factories
{
    public interface IFruitFactory
    {
        public IFruitCollidDetector CreateFruit(Vector3Int vector, FruitsEnum fruit);
    }
}