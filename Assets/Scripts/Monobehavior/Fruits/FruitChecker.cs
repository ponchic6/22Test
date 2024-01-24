using System;
using Enums;
using Factories;
using Services;
using UnityEngine;
using Zenject;

namespace Monobehavior.Fruits
{
    public class FruitChecker : MonoBehaviour, IFruitChecker
    {
        public event Action<bool> OnCheckFruitType;
    
        private ILevelFruitCreator _levelFruitCreator;
        private IUIHandlerFactory _uiHandlerFactory;

        [Inject]
        public void Constructor(ILevelFruitCreator levelFruitCreator, IUIHandlerFactory uiHandlerFactory)
        {
            _levelFruitCreator = levelFruitCreator;
            _uiHandlerFactory = uiHandlerFactory;

            SubscribeOnCollisionWithFruit();
        }
    
        private void SubscribeOnCollisionWithFruit()
        {
            foreach (var fruit in _levelFruitCreator.FruitList)
            {
                fruit.OnCollision += CheckCorrectBasket;
            }
        }

        private void CheckCorrectBasket(GameObject fruit)
        {
            FruitsEnum fruitType = fruit.GetComponent<FruitType>().GetFruitType;
            FruitsEnum basketType = _uiHandlerFactory.FruitBasketButtonsHandler.GetSelectedBasket();

            if (fruitType == basketType)
            {
                OnCheckFruitType?.Invoke(true);
            }

            else
            {
                OnCheckFruitType?.Invoke(false);
            }
        }
    }
}