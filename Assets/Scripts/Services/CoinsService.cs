using System;

namespace Services
{
    public class CoinsService : ICoinsService
    {
        public event Action<int> OnCoinsChange;
        
        private int _coins = 10;
        
        public int Coins => _coins;

        public void AddCoins(int coins)
        {
            _coins += coins;
            
            OnCoinsChange?.Invoke(_coins);
        }

        public void RemoveCoins(int coins)
        {   
            OnCoinsChange?.Invoke(_coins - coins);
            
            if (_coins - coins >= 0)
            {
                _coins -= coins;
            }
        }
    }
}