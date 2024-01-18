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
        [Inject] private IBonusService _bonusService;

        private GameStateMachine _gameStateMachine;

        public void SetGameStateMachine(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void RestartGame()
        {
            _bonusService.ClearBonusList();
            _levelFruitCreator.ClearLevel();
            _tractorFactory.DestroyTractor();
            _gameStateMachine.Enter<LoadMainMenuState>(); 
        }
    }
}