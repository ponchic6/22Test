using System;
using System.Collections.Generic;
using Monobehavior;

namespace Services
{
    public class BonusService : IBonusService
    {
        public event Action OnOpenedAllBonus;
        
        private const int _maxBonusButton = 3;

        private readonly ICoinsService _coinsService;

        private List<BonusEnum> _openedButtonBonusList = new List<BonusEnum>();

        public BonusService(ICoinsService coinsService)
        {
            _coinsService = coinsService;
        }

        public void OpenBonusButton(BonusEnum bonusEnum)
        {
            _openedButtonBonusList.Add(bonusEnum);

            if (_openedButtonBonusList.Count == _maxBonusButton)
            {   
                OnOpenedAllBonus?.Invoke();
                BonusEnum bonus = _openedButtonBonusList[0];
            
                foreach (BonusEnum currentBonus in _openedButtonBonusList)
                {
                    if (currentBonus != bonus)
                    {
                        return;
                    }
                }
                
                _coinsService.AddCoins(100);
            }
        }

        public void ClearBonusList()
        {
            _openedButtonBonusList.Clear();
        }
    }
}