namespace Infrastructure.StateMachine
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadMainMenu);
        }

        public void Exit()
        {
        
        }

        private void EnterLoadMainMenu()
        {
            _stateMachine.Enter<LoadMainMenuState>();
        }
    }
}
