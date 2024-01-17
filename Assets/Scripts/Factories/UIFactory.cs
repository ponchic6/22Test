using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefabs/Canvas";
    private const string CurrentLevelTextPath = "UIEllements/UIPrefabs/CurrentLevel";
    private const string TimerPath = "UIEllements/UIPrefabs/Timer";
    private const string FruitProgressPath = "UIEllements/UIPrefabs/FruitProgress";
    private const string FruitButtonsPath = "UIEllements/UIPrefabs/FruitButtons";
    private const string LossDisplayPath = "UIEllements/UIPrefabs/LossDispalyRoot";
    private const string MenuPanelPath = "UIEllements/UIPrefabs/MenuPanel";
    
    private readonly DiContainer _diContainer;
    private readonly IUIHandlerFactory _uiHandlerFactory;

    private IMenuButtonsHandler _menuButtonsHandler;
    private IFruitButtonsHandler _fruitButtonsHandler;

    private Transform _rootCanvas;
    private Transform _currentLevelText;
    private Transform _timer;
    private Transform _fruitProgress;
    private Transform _fruitButtons;
    private Transform _lossDisplay;
    private Transform _menuPanel;

    public Transform RootCanvas => _rootCanvas;
    public Transform CurrentLevelText => _currentLevelText;
    public Transform Timer => _timer;
    public Transform FruitProgress => _fruitProgress;
    public Transform FruitButtons => _fruitButtons;
    public Transform LossDisplay => _lossDisplay;
    public Transform MenuPanel => _menuPanel;

    public UIFactory(DiContainer diContainer, IUIHandlerFactory uiHandlerFactory)
    {_diContainer = diContainer;
        _uiHandlerFactory = uiHandlerFactory;
    }

    public Transform CreateCanvas()
    {
        Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
        _rootCanvas = Object.Instantiate(rootCanvas);
        return _rootCanvas;
    }

    public Transform CreateCurrentLevelText()
    {
        Transform levelText = Resources.Load<GameObject>(CurrentLevelTextPath).transform;
        _currentLevelText = Object.Instantiate(levelText, _rootCanvas);
        return _currentLevelText;
    }

    public Transform CreateTimer()
    {
        Transform timer = Resources.Load<GameObject>(TimerPath).transform;
        _timer = Object.Instantiate(timer, _rootCanvas);
        return _timer;
    }

    public Transform CreateFruitProgrerss()
    {
        Transform fruitProgress = Resources.Load<GameObject>(FruitProgressPath).transform;
        _fruitProgress = _diContainer.InstantiatePrefab(fruitProgress, _rootCanvas).transform;
        return _fruitProgress;
    }

    public Transform CreateFruitButtons()
    {
        _fruitButtons = _diContainer.InstantiatePrefabResource(FruitButtonsPath, _rootCanvas).transform;
        _fruitButtonsHandler = _uiHandlerFactory.CreateFruitButtonsHandler(_fruitButtons);
        BindFruitButton(_fruitButtons.GetChild(0));
        BindFruitButton(_fruitButtons.GetChild(1));
        return _fruitButtons;
    }

    public Transform CreateLossDisplay()
    {
        Transform lossDisplay = Resources.Load<GameObject>(LossDisplayPath).transform;
        
        if (_lossDisplay == null)
            _lossDisplay = Object.Instantiate(lossDisplay, _rootCanvas);
        
        return _lossDisplay;
    }

    public Transform CreateMenuPanel(GameStateMachine gameStateMachine)
    {
        _menuPanel = _diContainer.InstantiatePrefabResource(MenuPanelPath, _rootCanvas).transform;
        _menuButtonsHandler = _uiHandlerFactory.CreateMenuButtonsHandler(_menuPanel, gameStateMachine);
        BindMenuButton(_menuPanel.GetChild(0), "Level 1");
        BindMenuButton(_menuPanel.GetChild(1), "Level 2");
        BindMenuButton(_menuPanel.GetChild(2), "Level 3");
        return _lossDisplay;
    }

    private void BindMenuButton(Transform levelMenuButton, string levelName)
    {
        levelMenuButton
            .GetComponent<Button>()
            .onClick
            .AddListener(() => { _menuButtonsHandler.LoadLevel(levelName); });
    }

    private void BindFruitButton(Transform fruitButton)
    {
        fruitButton
            .GetComponent<Button>()
            .onClick
            .AddListener(() => { _fruitButtonsHandler.SelectFruitBasket(fruitButton); });
    }
}