using Infrastructure.StateMachine;
using Monobehavior;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Factories
{
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
        private IFruitBasketButtonsHandler _fruitBasketButtonsHandler;
        private IRestartButtonHandler _restartButtonHandler;

        private Transform _rootCanvas;
        private Transform _currentLevelText;
        private Transform _timer;
        private Transform _fruitProgress;
        private Transform _fruitButtons;
        private Transform _lossDisplay;
        private Transform _menuPanel;
        private GameStateMachine _gameStateMachine;

        public Transform RootCanvas => _rootCanvas;
        public Transform CurrentLevelText => _currentLevelText;
        public Transform Timer => _timer;
        public Transform FruitProgress => _fruitProgress;
        public Transform FruitButtons => _fruitButtons;
        public Transform LossDisplay => _lossDisplay;
        public Transform MenuPanel => _menuPanel;       

        public UIFactory(DiContainer diContainer, IUIHandlerFactory uiHandlerFactory)
        {    
            _diContainer = diContainer;         
            _uiHandlerFactory = uiHandlerFactory;
        }

        public void SetGameStateMachine(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void CreateCanvas()
        {
            Transform rootCanvas = Resources.Load<GameObject>(CanvasPath).transform;
            _rootCanvas = Object.Instantiate(rootCanvas);
        }

        public void CreateCurrentLevelText()
        {
            Transform levelText = Resources.Load<GameObject>(CurrentLevelTextPath).transform;
            _currentLevelText = Object.Instantiate(levelText, _rootCanvas);
        }

        public void CreateTimer()
        {
            Transform timer = Resources.Load<GameObject>(TimerPath).transform;
            _timer = Object.Instantiate(timer, _rootCanvas);
        }

        public void CreateFruitProgrerss()
        {
            Transform fruitProgress = Resources.Load<GameObject>(FruitProgressPath).transform;
            _fruitProgress = _diContainer.InstantiatePrefab(fruitProgress, _rootCanvas).transform;
        }

        public void CreateFruitButtons()
        {
            _fruitButtons = _diContainer.InstantiatePrefabResource(FruitButtonsPath, _rootCanvas).transform;
            _fruitBasketButtonsHandler = _uiHandlerFactory.CreateFruitButtonsHandler(_fruitButtons);
            BindFruitButton(_fruitButtons.GetChild(0));
            BindFruitButton(_fruitButtons.GetChild(1));
        }

        public void CreateLossDisplay()
        {
            Transform lossDisplay = Resources.Load<GameObject>(LossDisplayPath).transform;
            _lossDisplay = Object.Instantiate(lossDisplay, _rootCanvas);
            _restartButtonHandler = _uiHandlerFactory.CreateRestartButtonHandler(_lossDisplay, _gameStateMachine);
            BindRestartButton(_lossDisplay.GetChild(0).GetChild(0));
        }

        public void CreateMenuPanel()
        {
            _menuPanel = _diContainer.InstantiatePrefabResource(MenuPanelPath, _rootCanvas).transform;
            _menuButtonsHandler = _uiHandlerFactory.CreateMenuButtonsHandler(_menuPanel, _gameStateMachine);
            BindMenuButton(_menuPanel.GetChild(0), "Level 1");
            BindMenuButton(_menuPanel.GetChild(1), "Level 2");
            BindMenuButton(_menuPanel.GetChild(2), "Level 3");
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
                .AddListener(() => { _fruitBasketButtonsHandler.SelectFruitBasket(fruitButton); });
        }

        private void BindRestartButton(Transform restartButton)
        {
            restartButton
                .GetComponent<Button>()
                .onClick
                .AddListener(() => { _restartButtonHandler.RestartGame(); });
        }
    }
}