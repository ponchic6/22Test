using Factories;

namespace Infrastructure.StateMachine
{
    public class LoadMainMenuState : IState
    {
        private const string MainMenu = "MainMenu"; 
    
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter() =>
            _sceneLoader.Load(MainMenu, OnLoaded);

        public void Exit()
        {
        
        }

        private void OnLoaded()
        {
            _uiFactory.SetGameStateMachine(_gameStateMachine);
            _uiFactory.CreateCanvas();
            _uiFactory.CreateMenuPanel();
        }
    }
}