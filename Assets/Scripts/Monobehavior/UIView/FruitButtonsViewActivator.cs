using System;
using Services;
using UnityEngine;
using Zenject;

namespace Monobehavior.UIView
{
    public class FruitButtonsViewActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _appleButton;
        [SerializeField] private GameObject _tomatoButton;
        
        private IInputService _inputService;

        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnRightClockDown += UnhideButtons;
            _inputService.OnRightClockUp += HideButtons;
        }

        private void UnhideButtons()
        {
            _appleButton.SetActive(true);
            _tomatoButton.SetActive(true);
        }

        private void HideButtons()
        {
            _appleButton.SetActive(false);
            _tomatoButton.SetActive(false);
        }

        private void OnDestroy()
        {
            _inputService.OnRightClockDown -= UnhideButtons;
            _inputService.OnRightClockUp -= HideButtons;
        }
    }
}
