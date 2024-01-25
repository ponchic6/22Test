using System;
using UnityEngine;

namespace Services
{
    public interface IInputService
    {
        public event Action<Vector3> OnSwipe;
        public event Action OnRightClockDown;
        public event Action OnRightClockUp;
    }
}