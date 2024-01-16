using UnityEngine;

public interface IUIFactory
{
    public Transform CreateCanvas();
    public Transform CreateCurrentLevelText();
    public Transform CreateTimer();
    public Transform CreateFruitProgrerss();
    public Transform CreateFruitButtons();
    public Transform CreateLossDisplay();
    public Transform RootCanvas { get; }
    public Transform CurrentLevelText { get; }
    public Transform Timer { get; }
    public Transform FruitProgress { get; }
    public Transform FruitButtons { get; }
}