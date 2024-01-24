using System;

namespace Monobehavior.Fruits
{
    public interface IFruitChecker
    {
        public event Action<bool> OnCheckFruitType;
    }
}