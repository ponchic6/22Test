using Infrastructure.StateMachine;
using Monobehavior;
using UnityEngine;

namespace Factories
{
    public interface IUIHandlerFactory
    {
        public IMenuButtonsHandler CreateMenuButtonsHandler(Transform parent, GameStateMachine gameStateMachine);
        public IFruitBasketButtonsHandler CreateFruitButtonsHandler(Transform fruitButtons);
        public IRestartButtonHandler CreateRestartButtonHandler(Transform parent, GameStateMachine gameStateMachine);
        public IMenuButtonsHandler MenuButtonsHandler { get; }
        public IFruitBasketButtonsHandler FruitBasketButtonsHandler { get; }
        public IRestartButtonHandler RestartButtonHandler { get; }
    }
}