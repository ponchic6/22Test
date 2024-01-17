using UnityEngine;

public interface IFruitButtonsHandler
{
    public void SelectFruitBasket(Transform fruitButton);
    public FruitsEnum GetSelectedBasket();
}