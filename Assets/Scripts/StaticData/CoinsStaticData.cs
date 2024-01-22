using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(fileName = "CoinsStaticData")]
    public class CoinsStaticData : ScriptableObject
    {
        [SerializeField] private int _bonusReward;
        public int BonusReward => _bonusReward;
        
        public int CurrentCoins = 10;
         
    }
}