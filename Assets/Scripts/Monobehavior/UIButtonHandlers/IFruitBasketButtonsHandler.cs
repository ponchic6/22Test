using Enums;
using UnityEngine;

namespace Monobehavior.UIButtonHandlers
{
    public interface IFruitBasketButtonsHandler
    {
        public void SelectFruitBasket(Transform fruitButton);
        public FruitsEnum GetSelectedBasket();
    }
}