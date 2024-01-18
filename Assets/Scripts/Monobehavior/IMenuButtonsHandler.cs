using Infrastructure.StateMachine;
using StaticData;

namespace Monobehavior
{
    public interface IMenuButtonsHandler
    {
        public void Constructor(GameStateMachine gameStateMachine);
        public void LoadLevel(string levelName, LevelStaticData levelStaticData);
    }
}