using Infrastructure.StateMachine;

namespace Monobehavior.UIButtonHandlers
{
    public interface IRestartButtonHandler
    {
        public void SetGameStateMachine(GameStateMachine gameStateMachine);
        public void RestartGame();
    }
}