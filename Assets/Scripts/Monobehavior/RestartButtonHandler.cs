using Factories;
using Handlers;
using Infrastructure.StateMachine;
using Services;
using UnityEngine;
using Zenject;

namespace Monobehavior
{
    public class RestartButtonHandler : MonoBehaviour, IRestartButtonHandler
    {
        [Inject] private ITractorFactory _tractorFactory;
        [Inject] private ILevelFruitCreator _levelFruitCreator;
        [Inject] private ILossHandler _lossHandler;
    
        private GameStateMachine _gameStateMachine;

        public void Constructor(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void RestartGame()
        {   
            _levelFruitCreator.ClearDictionary();
            _tractorFactory.DestroyTractor();
            _lossHandler.UpdateLossStatus();
            _gameStateMachine.Enter<LoadMainMenuState>(); 
        }
    }
}