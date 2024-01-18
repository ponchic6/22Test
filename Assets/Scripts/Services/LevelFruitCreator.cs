using System;
using System.Collections.Generic;
using Factories;
using Monobehavior;
using StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public class LevelFruitCreator : ILevelFruitCreator
    {
        public event Action OnLastTakingFruit;
        
        private readonly IFruitFactory _fruitFactory;

        private List<IFruitCollidDetector> _fruitList = new List<IFruitCollidDetector>();
        private LevelStaticData _currentLevelStaticData;

        public LevelFruitCreator(IFruitFactory fruitFactory)
        {
            _fruitFactory = fruitFactory;
        }

        public List<IFruitCollidDetector> FruitList
            => _fruitList;
        public LevelStaticData CurrentLevelStaticData 
            => _currentLevelStaticData;

        public void InitializeFruitsOnLevel(LevelStaticData levelStaticData)
        {
            _currentLevelStaticData = levelStaticData;
            
            for (int i = 0; i < levelStaticData.FruitsPos.Count; i++)
            {
                IFruitCollidDetector fruit = _fruitFactory.CreateFruit(levelStaticData.FruitsPos[i], levelStaticData.FruitsEnums[i]);
                fruit.OnCollision += RemoveFruitFromList;
                _fruitList.Add(fruit);
            }
        }

        public void ClearLevel()
        {
            foreach (var fruit in _fruitList)
            {
                Object.Destroy(fruit.GetFruitTransform().gameObject);
            }
            
            _fruitList.Clear();
        }

        private void RemoveFruitFromList(GameObject fruit)
        {
            _fruitList.Remove(fruit.GetComponent<IFruitCollidDetector>());

            if (_fruitList.Count == 0)
            {
                OnLastTakingFruit?.Invoke();
            }
        }
    }
}