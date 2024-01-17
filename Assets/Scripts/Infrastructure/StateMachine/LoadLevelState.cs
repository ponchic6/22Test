using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly SceneLoader _sceneLoader;

    [Inject] private ITractorFactory _tractorFactory;
    [Inject] private IUIFactory _uiFactory;
    [Inject] private ILossHandler _lossHandler;
    [Inject] private ILevelFruitCreator _levelFruitCreator;
    
    public LoadLevelState(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName) 
        => _sceneLoader.Load(sceneName, OnLoaded);

    public void Exit()
    {
        
    }

    private void OnLoaded()
    {
        _levelFruitCreator.InitializeFruits();
        _tractorFactory.CreateTractor();
        _uiFactory.CreateCanvas();
        _uiFactory.CreateTimer();
        _uiFactory.CreateFruitProgrerss();
        _uiFactory.CreateCurrentLevelText();
        _uiFactory.CreateFruitButtons();
        _lossHandler.SubscribeOnTimeOver();
        _lossHandler.SubscribeOnIncorrrectChooseOfBasket();
    }
}