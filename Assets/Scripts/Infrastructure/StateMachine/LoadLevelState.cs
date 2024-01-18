using Factories;
using Handlers;
using Services;
using StaticData;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class LoadLevelState : IPayLoadState<string, LevelStaticData>
    {
        private readonly SceneLoader _sceneLoader;

        [Inject] private ITractorFactory _tractorFactory;
        [Inject] private IUIFactory _uiFactory;
        [Inject] private IWinLossHandler _winLossHandler;
        [Inject] private ILevelFruitCreator _levelFruitCreator;

        private LevelStaticData _levelStaticData;
            
        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName, LevelStaticData levelStaticData)
        {
            _levelStaticData = levelStaticData;
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        
        }

        private void OnLoaded()
        {
            _levelFruitCreator.InitializeFruitsOnLevel(_levelStaticData);
            _tractorFactory.CreateTractor();
            _uiFactory.CreateCanvas();
            _uiFactory.CreateTimer();
            _uiFactory.CreateFruitProgrerss(_levelStaticData.FruitsPos.Count);
            _uiFactory.CreateCurrentLevelText(_levelStaticData.LevelName);
            _uiFactory.CreateFruitButtons();
            _winLossHandler.SubscribeOnTimeOver();
            _winLossHandler.SubscribeOnIncorrectChooseOfBasket();
        }
    }
}