using Infrastructure.StateMachine;
using Services;
using StaticData;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {
        public void SetGameStateMachine(GameStateMachine gameStateMachine);
        public void CreateCanvas();
        public void CreateCurrentLevelText(string levelName);
        public void CreateTimer();
        public void CreateFruitProgrerss(int fruitsPosCount);
        public void CreateFruitButtons();
        public void CreateLossDisplay();
        public void CreateMenuPanel(ILevelsStaticDataService levelsStaticDataService);
        public void CreateCoinsPanel();
        public void CreateBonusPanel();
        public Transform RootCanvas { get; }
        public Transform CurrentLevelText { get; }
        public Transform Timer { get; }
        public Transform FruitProgress { get; }
        public Transform FruitButtons { get; }
        public Transform MenuPanel { get; }
        public Transform CoinsPanel { get; }
    }
}