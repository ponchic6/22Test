using Infrastructure.StateMachine;

namespace Monobehavior
{
    public interface IRestartButtonHandler
    {
        public void SetGameStateMachine(GameStateMachine gameStateMachine);
        public void RestartGame();
    }
}