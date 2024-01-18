using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Monobehavior
{
    public class BonusButtonHandler : MonoBehaviour
    {
        [SerializeField] private BonusEnum _bonusEnum;
        [SerializeField] private TMP_Text _text;
        private bool _canBeOpened = true;

        private IBonusService _bonusService;
            
        [Inject]
        public void Constructor(IBonusService bonusService)
        {
            _bonusService = bonusService;
            _bonusService.OnOpenedAllBonus += DisableButton;
        }

        public void OpenBonus()
        {
            if (_canBeOpened)
            {
                _bonusService.OpenBonusButton(_bonusEnum);
                _text.text = _bonusEnum.ToString();
            }
        }

        private void DisableButton()
        {
            _canBeOpened = false;
        }
    }
}
