using Infrastructure.StateMachine;
using Monobehavior;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class UIHandlerFactory : IUIHandlerFactory
    {
        private const string MenuButtonsHandlerPath = "UIEllements/UIHandlers/MenuButtonsHandler";
        private const string FruitButtonsHandlerPath = "UIEllements/UIHandlers/FruitButtonsHandler";
        private const string RestartButtonHanderPath = "UIEllements/UIHandlers/RestartButtonHander";
    
        private readonly DiContainer _diContainer;

        private IMenuButtonsHandler _menuButtonsHandler;
        private IFruitBasketButtonsHandler _fruitBasketButtonsHandler;
        private IRestartButtonHandler _restartButtonHandler;

        public IMenuButtonsHandler MenuButtonsHandler => _menuButtonsHandler;
        public IFruitBasketButtonsHandler FruitBasketButtonsHandler => _fruitBasketButtonsHandler;
        public IRestartButtonHandler RestartButtonHandler => _restartButtonHandler;

        public UIHandlerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public IRestartButtonHandler CreateRestartButtonHandler(Transform parent, GameStateMachine gameStateMachine)
        {
            _restartButtonHandler =
                _diContainer.InstantiatePrefabResourceForComponent<IRestartButtonHandler>(RestartButtonHanderPath, parent);
            
            _restartButtonHandler.Constructor(gameStateMachine);
            return _restartButtonHandler;
        }

        public IMenuButtonsHandler CreateMenuButtonsHandler(Transform parent, GameStateMachine gameStateMachine)
        {
            _menuButtonsHandler =
                _diContainer.InstantiatePrefabResourceForComponent<IMenuButtonsHandler>(MenuButtonsHandlerPath, parent);
            
            _menuButtonsHandler.Constructor(gameStateMachine);
            return _menuButtonsHandler;
        }

        public IFruitBasketButtonsHandler CreateFruitButtonsHandler(Transform parent)
        {
            _fruitBasketButtonsHandler =
                _diContainer
                .InstantiatePrefabResourceForComponent<IFruitBasketButtonsHandler>(FruitButtonsHandlerPath, parent);
            return _fruitBasketButtonsHandler;
        }
    }
}