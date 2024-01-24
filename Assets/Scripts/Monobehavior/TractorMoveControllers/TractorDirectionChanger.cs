using System;
using DG.Tweening;
using Services;
using UnityEngine;
using Zenject;

namespace Monobehavior
{
    public class TractorDirectionChanger : MonoBehaviour, ITractorDirectionChanger
    {
        private IInputService _inputService;
        private Tween _rotateTween;

        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnSwipe += ChangeDirectionMove;
        }
    
        public void ChangeDirectionMove(Vector3 direction)
        {
            _rotateTween = transform.DORotate(Quaternion.LookRotation(direction).eulerAngles, 0.5f);
        }

        private void OnDisable()
        {
            _rotateTween.Kill();
            _inputService.OnSwipe -= ChangeDirectionMove;
        }

        private void OnDestroy()
        {
            _rotateTween.Kill();
            _inputService.OnSwipe -= ChangeDirectionMove;
        }
    }
}