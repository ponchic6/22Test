using UnityEngine;
using Zenject;

public class UIFactory : IUIFactory
{
    private const string CanvasPath = "UIEllements/UIPrefabs/Canvas";
    private const string CurrentLevelTextPath = "UIEllements/UIPrefabs/CurrentLevel";
    private const string TimerPath = "UIEllements/UIPrefabs/Timer";
    private const string FruitProgressPath = "UIEllements/UIPrefabs/FruitProgress";
    private const string FruitButtonsPath = "UIEllements/UIPrefabs/FruitButtons";
    private const string LossDisplayPath = "UIEllements/UIPrefabs/LossDispalyRoot";
    
    private readonly DiContainer _diContainer;

    private Transform _rootCanvas;
    private Transform _currentLevelText;
    private Transform _timer;
    private Transform _fruitProgress;
    private Transform _fruitButtons;
    private Transform _lossDisplay;

    public Transform RootCanvas => _rootCanvas;
    public Transform CurrentLevelText => _currentLevelText;
    public Transform Timer => _timer;
    public Transform FruitProgress => _fruitProgress;
    public Transform FruitButtons => _fruitButtons;
    public Transform LossDisplay => _lossDisplay;

    public UIFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
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
        Transform fruitButtons = Resources.Load<GameObject>(FruitButtonsPath).transform;
        _fruitButtons = Object.Instantiate(fruitButtons, _rootCanvas);
        return _fruitButtons;
    }

    public Transform CreateLossDisplay()
    {
        Transform lossDisplay = Resources.Load<GameObject>(LossDisplayPath).transform;
        _lossDisplay = Object.Instantiate(lossDisplay, _rootCanvas);
        return _lossDisplay;
    }
}