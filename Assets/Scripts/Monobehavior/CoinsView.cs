using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Monobehavior
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsText;
        
        private ICoinsService _coinsService;
            
        [Inject]
        public void Constructor(ICoinsService coinsService)
        {
            _coinsService = coinsService;
            UpdateCoinsView(_coinsService.Coins);
            _coinsService.OnCoinsChange += UpdateCoinsView;
        }
        
        private void UpdateCoinsView(int coins)
        {
            _coinsText.text = coins.ToString();
        }
    }
}
