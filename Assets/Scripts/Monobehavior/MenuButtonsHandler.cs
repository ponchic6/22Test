using Infrastructure.StateMachine;
using UnityEngine;

namespace Monobehavior
{
    public class MenuButtonsHandler : MonoBehaviour, IMenuButtonsHandler
    {
        private GameStateMachine _gameStateMachine;
    
        public void Constructor(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
    
        public void LoadLevel(string levelName)
        {
            _gameStateMachine.Enter<LoadLevelState, string>(levelName);
        }
    }
}