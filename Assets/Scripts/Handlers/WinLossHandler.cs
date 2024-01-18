﻿using Factories;
using Monobehavior;
using Services;
using UnityEngine;

namespace Handlers
{
    public class WinLossHandler : IWinLossHandler
    {
        private readonly IUIFactory _uiFactory;
        private readonly ITractorFactory _tractorFactory;
        private readonly ILevelFruitCreator _levelFruitCreator;
        private readonly ICoinsService _coinsService;

        public WinLossHandler(IUIFactory uiFactory, ITractorFactory tractorFactory, 
            ILevelFruitCreator levelFruitCreator, ICoinsService coinsService)
        {
            _uiFactory = uiFactory;
            _tractorFactory = tractorFactory;
            _levelFruitCreator = levelFruitCreator;
            _coinsService = coinsService;
            _levelFruitCreator.OnLastTakingFruit += ToWin;
        }

        public void SubscribeOnTimeOver()
        {
            _uiFactory.Timer.GetComponent<ITimer>().OnTimeOver += ToLose;
        }

        public void SubscribeOnIncorrectChooseOfBasket()
        {
            _tractorFactory.GetTractor().GetComponent<IFruitChecker>().OnCheckFruitType += TryToLose;
        }
        
        private void TryToLose(bool obj)
        {
            if (obj == false)
                ToLose();
        }

        private void ToWin()
        {
            _coinsService.AddCoins(_levelFruitCreator.CurrentLevelStaticData.RewardForLevel);
            _uiFactory.Timer.GetComponent<ITimer>().DisableTimer();
            _tractorFactory.DestroyTractor();
            _uiFactory.CreateBonusPanel();
        }

        private void ToLose()
        {
            _uiFactory.Timer.GetComponent<ITimer>().DisableTimer();
            _tractorFactory.DestroyTractor();
            _uiFactory.CreateLossDisplay();
        }
    }
}