using System;
using StaticData;

namespace Services
{
    public class CoinsService : ICoinsService
    {
        public event Action<int> OnCoinsChange;
        
        private readonly CoinsStaticData _coinsStaticData;

        private int _coins;
        public int Coins => _coins;

        public CoinsService(CoinsStaticData coinsStaticData)
        {
            _coinsStaticData = coinsStaticData;
            _coins = _coinsStaticData.CurrentCoins;
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
            _coinsStaticData.CurrentCoins += coins;
            
            OnCoinsChange?.Invoke(_coins);
        }

        public void RemoveCoins(int coins)
        {   
            OnCoinsChange?.Invoke(_coins - coins);
            
            if (_coins - coins >= 0)
            {
                _coins -= coins;
                _coinsStaticData.CurrentCoins -= coins;
            }
        }
    }
}