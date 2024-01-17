using UnityEngine;

public class UIHandlerFactory : IUIHandlerFactory
{
    private const string MenuButtonsHandlerPath = "UIEllements/UIHandlers/MenuButtonsHandler";
    private const string FruitButtonsHandlerPath = "UIEllements/UIHandlers/FruitButtonsHandler";

    private IMenuButtonsHandler _menuButtonsHandler;
    private IFruitButtonsHandler _fruitButtonsHandler;

    public IMenuButtonsHandler MenuButtonsHandler => _menuButtonsHandler;
    public IFruitButtonsHandler FruitButtonsHandler => _fruitButtonsHandler;

    public IMenuButtonsHandler CreateMenuButtonsHandler(Transform parent, GameStateMachine gameStateMachine)
    {
        Transform menuButtonsHandlerPrefab = Resources.Load<Transform>(MenuButtonsHandlerPath);
        
        _menuButtonsHandler =
            Object.Instantiate(menuButtonsHandlerPrefab, parent).GetComponent<IMenuButtonsHandler>();
        
        _menuButtonsHandler.Constructor(gameStateMachine);
        return _menuButtonsHandler;
    }

    public IFruitButtonsHandler CreateFruitButtonsHandler(Transform parent)
    {
        Transform fruitButtonsHandlerPrefab = Resources.Load<Transform>(FruitButtonsHandlerPath);
        
        _fruitButtonsHandler =
            Object.Instantiate(fruitButtonsHandlerPrefab, parent).GetComponent<IFruitButtonsHandler>();

        return _fruitButtonsHandler;
    }
}