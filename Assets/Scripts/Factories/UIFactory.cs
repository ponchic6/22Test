using Infrastructure.StateMachine;
using Monobehavior;
using Services;
using TMPro;
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
        private const string CoinsPanelPath = "UIEllements/UIPrefabs/CoinsPanel";
        private const string BonusPanelPath = "UIEllements/UIPrefabs/Bonus";

        private readonly DiContainer _diContainer;
        private readonly IUIHandlerFactory _uiHandlerFactory;
        private readonly ILevelStaticDataService _levelStaticDataService;

        private IMenuButtonsHandler _menuButtonsHandler;
        private IFruitBasketButtonsHandler _fruitBasketButtonsHandler;
        private IRestartButtonHandler _restartButtonHandler;

        private Transform _rootCanvas;
        private Transform _currentLevelText;
        private Transform _timer;
        private Transform _fruitProgress;
        private Transform _fruitButtons;
        private Transform _lossDisplay;
        private Transform _bonusPanel;
        private Transform _menuPanel;
        private Transform _coinsPanel;
        private GameStateMachine _gameStateMachine;
        
        public Transform RootCanvas => _rootCanvas;
        public Transform CurrentLevelText => _currentLevelText;
        public Transform Timer => _timer;
        public Transform FruitProgress => _fruitProgress;
        public Transform FruitButtons => _fruitButtons;
        public Transform LossDisplay => _lossDisplay;
        public Transform MenuPanel => _menuPanel;
        public Transform CoinsPanel => _coinsPanel;


        public UIFactory(DiContainer diContainer, IUIHandlerFactory uiHandlerFactory, ILevelStaticDataService levelStaticDataService)
        {    
            _diContainer = diContainer;         
            _uiHandlerFactory = uiHandlerFactory;
            _levelStaticDataService = levelStaticDataService;
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

        public void CreateCurrentLevelText(string levelName)
        {
            Transform levelText = Resources.Load<GameObject>(CurrentLevelTextPath).transform;
            _currentLevelText = Object.Instantiate(levelText, _rootCanvas);
            _currentLevelText.GetComponent<TMP_Text>().text = levelName;
        }

        public void CreateTimer()
        {
            Transform timer = Resources.Load<GameObject>(TimerPath).transform;
            _timer = Object.Instantiate(timer, _rootCanvas);
        }

        public void CreateFruitProgrerss(int fruitsPosCount)
        {
            Transform fruitProgress = Resources.Load<GameObject>(FruitProgressPath).transform;
            _fruitProgress = _diContainer.InstantiatePrefab(fruitProgress, _rootCanvas).transform;
            _fruitProgress.GetComponent<IFruitProgressIncreaser>().SetFruitLimit(fruitsPosCount);
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
            BindMenuButton(_menuPanel.GetChild(0),_menuPanel.GetChild(3), "Level 1", 0);
            BindMenuButton(_menuPanel.GetChild(1), _menuPanel.GetChild(4), "Level 2", 1);
            BindMenuButton(_menuPanel.GetChild(2), _menuPanel.GetChild(5), "Level 3", 2);
        }

        public void CreateCoinsPanel()
        {
            _coinsPanel = _diContainer.InstantiatePrefabResource(CoinsPanelPath, _rootCanvas)
                .transform;
        }

        public void CreateBonusPanel()
        {
            _bonusPanel = _diContainer.InstantiatePrefabResource(BonusPanelPath, _rootCanvas).transform;
            _restartButtonHandler = _uiHandlerFactory.CreateRestartButtonHandler(_bonusPanel, _gameStateMachine);
            BindRestartButton(_bonusPanel.GetChild(1));
        }

        private void BindMenuButton(Transform levelMenuButton, Transform unblockButton, string levelName, int levelIndex)
        {
            levelMenuButton
                .GetComponent<Button>()
                .onClick
                .AddListener(() => { _menuButtonsHandler.LoadLevel(levelName, _levelStaticDataService.LevelConfigsList[levelIndex]); });
            
            unblockButton.GetComponent<ILevelButtonUnblocker>().SetLevelStaticData(_levelStaticDataService.LevelConfigsList[levelIndex]);

            if (!_levelStaticDataService.LevelConfigsList[levelIndex].IsLevelUnblock)
            {
                levelMenuButton.GetComponent<Button>().interactable = false;
                unblockButton.GetComponent<Button>().interactable = true;
            }

            else
            {
                unblockButton.GetComponent<Button>().interactable = false;
            }
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