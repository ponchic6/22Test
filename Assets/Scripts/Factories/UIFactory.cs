using Infrastructure.StateMachine;
using Monobehavior.UIButtonHandlers;
using Monobehavior.UIView;
using Services;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IUIHandlerFactory _uiHandlerFactory;
        private readonly ILevelsStaticDataService _levelsStaticDataService;
        private readonly PathStaticData _pathStaticData;

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

        public UIFactory(DiContainer diContainer, IUIHandlerFactory uiHandlerFactory,
            ILevelsStaticDataService levelsStaticDataService, PathStaticData pathStaticData)
        {    
            _diContainer = diContainer;         
            _uiHandlerFactory = uiHandlerFactory;
            _levelsStaticDataService = levelsStaticDataService;
            _pathStaticData = pathStaticData;
        }

        public void SetGameStateMachine(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void CreateCanvas()
        {
            Transform rootCanvas = Resources.Load<GameObject>(_pathStaticData.UIPathStaticData.CanvasPath).transform;
            _rootCanvas = Object.Instantiate(rootCanvas);
        }

        public void CreateCurrentLevelText(string levelName)
        {
            Transform levelText = Resources.Load<GameObject>(_pathStaticData.UIPathStaticData.CurrentLevelTextPath).transform;
            _currentLevelText = Object.Instantiate(levelText, _rootCanvas);
            _currentLevelText.GetComponent<TMP_Text>().text = levelName;
        }

        public void CreateTimer(int seconds)
        {
            Transform timer = Resources.Load<GameObject>(_pathStaticData.UIPathStaticData.TimerPath).transform;
            _timer = Object.Instantiate(timer, _rootCanvas);
            _timer.GetComponent<ITimer>().SetTimer(seconds);
        }

        public void CreateFruitProgrerss(int fruitsPosCount)
        {
            Transform fruitProgress = Resources.Load<GameObject>(_pathStaticData.UIPathStaticData.FruitProgressPath).transform;
            _fruitProgress = _diContainer.InstantiatePrefab(fruitProgress, _rootCanvas).transform;
            _fruitProgress.GetComponent<IFruitProgressIncreaser>().SetFruitLimit(fruitsPosCount);
        }

        public void CreateFruitButtons()
        {
            _fruitButtons = _diContainer.
                InstantiatePrefabResource(_pathStaticData.UIPathStaticData.FruitButtonsPath, _rootCanvas).transform;
            _fruitBasketButtonsHandler = _uiHandlerFactory.CreateFruitButtonsHandler(_fruitButtons);
            BindFruitButton(_fruitButtons.GetChild(0));
            BindFruitButton(_fruitButtons.GetChild(1));
        }

        public void CreateLossDisplay()
        {
            Transform lossDisplay = Resources.Load<GameObject>(_pathStaticData.UIPathStaticData.LossDisplayPath).transform;
            _lossDisplay = Object.Instantiate(lossDisplay, _rootCanvas);
            _restartButtonHandler = _uiHandlerFactory.CreateRestartButtonHandler(_lossDisplay, _gameStateMachine);
            BindRestartButton(_lossDisplay.GetChild(0).GetChild(0));
        }

        public void CreateMenuPanel(ILevelsStaticDataService levelsStaticDataService)
        {
            _menuPanel = _diContainer.
                InstantiatePrefabResource(_pathStaticData.UIPathStaticData.MenuPanelPath, _rootCanvas).transform;
            _menuButtonsHandler = _uiHandlerFactory.CreateMenuButtonsHandler(_menuPanel, _gameStateMachine);

            for (int i = 0; i < levelsStaticDataService.LevelConfigsList.Count; i++)
            {
                Transform levelButtonsPair = _diContainer.
                    InstantiatePrefabResource(_pathStaticData.UIPathStaticData.LevelButtonsPairPath, _menuPanel).transform;
                LevelStaticData currentLevelStaticData = levelsStaticDataService.LevelConfigsList[i];
                
                SetLevelButtonsView(levelButtonsPair, i, currentLevelStaticData);
                BindMenuButton(levelButtonsPair.GetChild(0), levelButtonsPair.GetChild(1),
                    currentLevelStaticData.LevelName, i);
            }
        }

        public void CreateCoinsPanel()
        {
            _coinsPanel = _diContainer.InstantiatePrefabResource(_pathStaticData.UIPathStaticData.CoinsPanelPath, _rootCanvas)
                .transform;
        }

        public void CreateBonusPanel()
        {
            _bonusPanel = _diContainer.InstantiatePrefabResource(_pathStaticData.UIPathStaticData.BonusPanelPath, _rootCanvas).transform;
            _restartButtonHandler = _uiHandlerFactory.CreateRestartButtonHandler(_bonusPanel, _gameStateMachine);
            BindRestartButton(_bonusPanel.GetChild(1));
        }

        private static void SetLevelButtonsView(Transform levelButtonsPair, int LevelNumber,
            LevelStaticData currentLevelStaticData)
        {
            levelButtonsPair.position += new Vector3(0, -100, 0) * LevelNumber;

            levelButtonsPair.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text =
                currentLevelStaticData.LevelName;

            levelButtonsPair.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text =
                currentLevelStaticData.CostForLevel.ToString();
        }

        private void BindMenuButton(Transform levelMenuButton, Transform unblockButton, string levelName, int levelIndex)
        {
            levelMenuButton
                .GetComponent<Button>()
                .onClick
                .AddListener(() => { _menuButtonsHandler.LoadLevel(levelName, _levelsStaticDataService.LevelConfigsList[levelIndex]); });
            
            unblockButton.GetComponent<ILevelButtonUnblocker>().SetLevelStaticData(_levelsStaticDataService.LevelConfigsList[levelIndex]);

            SetBlockStatusButton(levelMenuButton, unblockButton, levelIndex);
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

        private void SetBlockStatusButton(Transform levelMenuButton, Transform unblockButton, int levelIndex)
        {
            if (!_levelsStaticDataService.LevelConfigsList[levelIndex].IsLevelUnblock)
            {
                levelMenuButton.GetComponent<Button>().interactable = false;
                unblockButton.GetComponent<Button>().interactable = true;
            }

            else
            {
                unblockButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}