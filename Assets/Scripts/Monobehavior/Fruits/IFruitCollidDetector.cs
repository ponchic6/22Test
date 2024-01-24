using System;
using UnityEngine;

namespace Monobehavior.Fruits
{
    public interface IFruitCollidDetector
    {
        public event Action<GameObject> OnCollision;
        public void SetFruitPos(Vector3Int vector3Int);
        public Transform GetFruitTransform();
    }
}