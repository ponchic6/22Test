using Infrastructure.StateMachine;

namespace Monobehavior
{
    public interface IRestartButtonHandler
    {
        public void Constructor(GameStateMachine gameStateMachine);
        public void RestartGame();
    }
}