using System;
using UnityEngine;

namespace Monobehavior
{
    public class FruitCollidDetector : MonoBehaviour, IFruitCollidDetector
    {
        public event Action<GameObject> OnCollision;

        private void OnTriggerEnter(Collider other)
        {
            OnCollision?.Invoke(gameObject);
            Destroy(gameObject);
        }

        public void SetFruitPos(Vector3Int vector3Int)
        {
            transform.position = vector3Int;
        }
        
        public Transform GetFruitTransform()
        {
            return transform;
        }
    }
}
