using System;

namespace Services
{
    public interface ICoinsService
    {
        public event Action<int> OnCoinsChange;
        public void AddCoins(int coins);
        public void RemoveCoins(int coins);
        public int Coins { get; }
    }
}