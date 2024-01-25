using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(fileName = "UIPathStaticData")]
    public class UIPathStaticData : ScriptableObject
    {
        [SerializeField] private string _canvasPath;
        [SerializeField] private string _currentLevelTextPath;
        [SerializeField] private string _timerPath;
        [SerializeField] private string _fruitProgressPath;
        [SerializeField] private string _fruitButtonsPath;
        [SerializeField] private string _lossDisplayPath;
        [SerializeField] private string _menuPanelPath;
        [SerializeField] private string _coinsPanelPath;
        [SerializeField] private string _bonusPanelPath;
        [SerializeField] private string _levelButtonsPairPath;

        public string CanvasPath => _canvasPath;
        public string CurrentLevelTextPath => _currentLevelTextPath;
        public string TimerPath => _timerPath;
        public string FruitProgressPath => _fruitProgressPath;
        public string FruitButtonsPath => _fruitButtonsPath;
        public string LossDisplayPath => _lossDisplayPath;
        public string MenuPanelPath => _menuPanelPath;
        public string CoinsPanelPath => _coinsPanelPath;
        public string BonusPanelPath => _bonusPanelPath;
        public string LevelButtonsPairPath => _levelButtonsPairPath;
    }
}