using Infrastructure.StateMachine;
using StaticData;
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
    
        public void LoadLevel(string levelName, LevelStaticData levelStaticData)
        {
            _gameStateMachine.Enter<LoadLevelState, string, LevelStaticData>(levelName, levelStaticData);
        }
    }
}