using Monobehavior;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class FruitFactory : IFruitFactory
    {   
        private const string FruitPath = "Fruits/Apple";
    
        private readonly DiContainer _diContainer;

        public FruitFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public IFruitCollidDetector CreateFruit(Vector3Int vector)
        {
            IFruitCollidDetector fruit = _diContainer.InstantiatePrefabResourceForComponent<IFruitCollidDetector>(FruitPath);
            fruit.SetFruitPos(vector);
            return fruit;
        }
    }
}