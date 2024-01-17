using Infrastructure.StateMachine;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {
        public void SetGameStateMachine(GameStateMachine gameStateMachine);
        public void CreateCanvas();
        public void CreateCurrentLevelText();
        public void CreateTimer();
        public void CreateFruitProgrerss();
        public void CreateFruitButtons();
        public void CreateLossDisplay();
        public void CreateMenuPanel();
        public Transform RootCanvas { get; }
        public Transform CurrentLevelText { get; }
        public Transform Timer { get; }
        public Transform FruitProgress { get; }
        public Transform FruitButtons { get; }
        public Transform MenuPanel { get; }                         
    }
}