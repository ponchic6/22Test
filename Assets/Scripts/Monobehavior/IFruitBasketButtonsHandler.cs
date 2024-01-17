using Enums;
using UnityEngine;

namespace Monobehavior
{
    public interface IFruitBasketButtonsHandler
    {
        public void SelectFruitBasket(Transform fruitButton);
        public FruitsEnum GetSelectedBasket();
    }
}