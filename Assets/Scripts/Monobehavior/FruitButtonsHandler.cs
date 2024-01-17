using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitButtonsHandler : MonoBehaviour, IFruitButtonsHandler
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