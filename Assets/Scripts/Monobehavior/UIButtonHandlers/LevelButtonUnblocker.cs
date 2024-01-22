using Services;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Monobehavior.UIButtonHandlers
{
    public class LevelButtonUnblocker : MonoBehaviour, ILevelButtonUnblocker
    {
        [SerializeField] private Button _levelButton;

        private LevelStaticData _levelStaticData;
        private ICoinsService _coinsService;
        
        [Inject]
        public void Constructor(ICoinsService coinsService)
        {
            _coinsService = coinsService;
        }

        public void SetLevelStaticData(LevelStaticData levelStaticData)
        {
            _levelStaticData = levelStaticData;
        }

        public void TryUnblockLevelButton()
        {
            if (_coinsService.Coins - _levelStaticData.CostForLevel >= 0)
            {
                _levelButton.interactable = true;
                _levelStaticData.IsLevelUnblock = true;    
                _coinsService.RemoveCoins(_levelStaticData.CostForLevel);
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }
}
