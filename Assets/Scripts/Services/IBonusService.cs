using System;
using Monobehavior;

namespace Services
{
    public interface IBonusService
    {
        public event Action OnOpenedAllBonus;
        public void OpenBonusButton(BonusEnum bonusEnum);
        public void ClearBonusList();
    }
}