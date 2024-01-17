using System.Collections.Generic;
using Factories;
using Monobehavior;
using UnityEngine;

namespace Services
{
    public class LevelFruitCreator : ILevelFruitCreator
    {
        private readonly IFruitFactory _fruitFactory;

        private Dictionary<Vector3Int, IFruitCollidDetector> _fruitDictionary = new Dictionary<Vector3Int, IFruitCollidDetector>();

        public LevelFruitCreator(IFruitFactory fruitFactory)
        {
            _fruitFactory = fruitFactory;
        }

        public Dictionary<Vector3Int, IFruitCollidDetector> GetFruitDictionary() 
            => _fruitDictionary;

        public void InitializeFruitsOnLevel()
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3Int vector3Int = new Vector3Int(2 + 2 * i, 0, 2 + 2 * i);
                IFruitCollidDetector fruit = _fruitFactory.CreateFruit(vector3Int);
                _fruitDictionary.Add(vector3Int, fruit);
            }
        }

        public void ClearDictionary()
        {
            _fruitDictionary.Clear();
        }
    }
}