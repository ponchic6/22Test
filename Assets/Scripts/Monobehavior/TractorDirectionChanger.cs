using Services;
using UnityEngine;
using Zenject;

namespace Monobehavior
{
    public class TractorDirectionChanger : MonoBehaviour, ITractorDirectionChanger
    {
        private IInputService _inputService;
    
        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnSwipe += ChangeDirectionMove;
        }
    
        public void ChangeDirectionMove(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction.normalized);
        }

        private void OnDestroy()
        {
            _inputService.OnSwipe -= ChangeDirectionMove;
        }
    }
}