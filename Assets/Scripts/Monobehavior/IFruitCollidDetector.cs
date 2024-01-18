using System;
using UnityEngine;

namespace Monobehavior
{
    public interface IFruitCollidDetector
    {
        public event Action<GameObject> OnCollision;
        public void SetFruitPos(Vector3Int vector3Int);
        public Transform GetFruitTransform();
    }
}