using Enums;
using Monobehavior;
using Monobehavior.Fruits;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class FruitFactory : IFruitFactory
    {   
        private const string ApplePath = "Fruits/Apple";
        private const string TomatoPath = "Fruits/Tomato";
    
        private readonly DiContainer _diContainer;

        public FruitFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public IFruitCollidDetector CreateFruit(Vector3Int vector, FruitsEnum fruit)
        {
            IFruitCollidDetector fruitClone = null;
            
            switch (fruit)
            {
                case FruitsEnum.Apple:
                    fruitClone = _diContainer.InstantiatePrefabResourceForComponent<IFruitCollidDetector>(ApplePath);
                    fruitClone.SetFruitPos(vector);
                    break;
                
                case FruitsEnum.Tomato:
                    fruitClone = _diContainer.InstantiatePrefabResourceForComponent<IFruitCollidDetector>(TomatoPath);
                    fruitClone.SetFruitPos(vector);
                    break;
            }
            
            return fruitClone;
        }
    }
}