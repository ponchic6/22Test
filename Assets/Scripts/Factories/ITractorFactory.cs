using UnityEngine;

namespace Factories
{
    public interface ITractorFactory
    {
        public void CreateTractor();
        public void DestroyTractor();
        public Transform GetTractor();
    }
}