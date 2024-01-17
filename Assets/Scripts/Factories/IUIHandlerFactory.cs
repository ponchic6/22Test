using UnityEngine;

public interface IUIHandlerFactory
{
    public IMenuButtonsHandler CreateMenuButtonsHandler(Transform parent, GameStateMachine gameStateMachine);
    public IFruitButtonsHandler CreateFruitButtonsHandler(Transform fruitButtons);
    public IMenuButtonsHandler MenuButtonsHandler { get; }
    public IFruitButtonsHandler FruitButtonsHandler { get; }
}