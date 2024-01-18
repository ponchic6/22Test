using System;
using Services;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Monobehavior
{
    public class LevelButtonUnblocker : MonoBehaviour, ILevelButtonUnblocker
    {
        [SerializeField] private Button _levelButton;
        [SerializeField] private int _costForUnblock;
        
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

        public void UnblockLevelButton()
        {
            if (_coinsService.Coins - _costForUnblock >= 0)
            {
                _levelButton.interactable = true;
                _levelStaticData.IsLevelUnblock = true;    
                _coinsService.RemoveCoins(_costForUnblock);
                gameObject.GetComponent<Button>().interactable = false;
            }
        }

        private void OnValidate()
        {
            GetComponentInChildren<TMP_Text>().text = _costForUnblock.ToString();
        }
    }
}
