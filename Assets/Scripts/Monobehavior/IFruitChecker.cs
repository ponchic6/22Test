using System;

namespace Monobehavior
{
    public interface IFruitChecker
    {
        public event Action<bool> OnCheckFruitType;
    }
}