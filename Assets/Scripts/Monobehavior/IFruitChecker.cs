using System;

public interface IFruitChecker
{
    public event Action<bool> OnCheckFruitType;
}