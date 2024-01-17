using Enums;
using UnityEngine;

namespace Monobehavior
{
    public class FruitBasketButtonsHandler : MonoBehaviour, IFruitBasketButtonsHandler
    {
        private FruitsEnum _currentSelectedButton = FruitsEnum.Apple;
    
        public void SelectFruitBasket(Transform fruitButton)
        {
            _currentSelectedButton = fruitButton.GetComponent<FruitType>().GetFruitType;
        }

        public FruitsEnum GetSelectedBasket()
        {
            return _currentSelectedButton;
        }
    }
}