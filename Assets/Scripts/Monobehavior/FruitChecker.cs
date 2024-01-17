using System;
using UnityEngine;
using Zenject;

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

        SubscribeOnCollision();
    }
    
    private void SubscribeOnCollision()
    {
        foreach (var fruitKetValuePair in _levelFruitCreator.GetFruitDictionary())
        {
            fruitKetValuePair.Value.OnCollision += CheckCorrectBasket;
        }
    }

    private void CheckCorrectBasket(GameObject fruit)
    {
        FruitsEnum fruitType = fruit.GetComponent<FruitType>().GetFruitType;
        FruitsEnum basketType = _uiHandlerFactory.FruitButtonsHandler.GetSelectedBasket();

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