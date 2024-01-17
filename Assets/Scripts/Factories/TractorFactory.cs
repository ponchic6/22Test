using UnityEngine;
using Zenject;

namespace Factories
{
    public class TractorFactory : ITractorFactory
    {
        private const string TractorPath = "Tractor/TractorPrefab";
    
        private readonly DiContainer _diContainer;

        private GameObject _tractor;
    
        public TractorFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public void CreateTractor()
        {   
            if (_tractor == null)
                _tractor = _diContainer.InstantiatePrefabResource(TractorPath);
        }

        public void DestroyTractor()
        {   
            if (_tractor != null)
                Object.Destroy(_tractor);
        }

        public Transform GetTractor()
        {
            return _tractor.transform;
        }
    }
}