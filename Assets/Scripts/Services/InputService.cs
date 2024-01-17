using System;
using UnityEngine;

namespace Services
{
    public class InputService : IInputService
    {
        public event Action<Vector3> OnSwipe;

        private const float Eps = 10;
        
        private bool _canSwipe;
        private Vector3 _startMousePos;

        public InputService(ITickService tickService)
        {
            tickService.OnTick += CheckSwipe;
            tickService.OnTick += CheckTouch;
        }

        private void CheckTouch()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _canSwipe = true;
                _startMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _canSwipe = false;
            }
        }

        private void CheckSwipe()
        {
            if (_canSwipe && Vector3.Distance(Input.mousePosition, _startMousePos) > Eps)
            {
                _canSwipe = false;
                Vector3 direction = Input.mousePosition - _startMousePos;

                direction = ToRoundVector3(direction);
                
                OnSwipe?.Invoke(direction);
            }
        }

        private Vector3 ToRoundVector3(Vector3 direction)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    direction = Vector3.right;
                }

                else
                {
                    direction = Vector3.left;
                }
            }

            else
            {
                if (direction.y > 0)
                {
                    direction = Vector3.forward;
                }

                else
                {
                    direction = Vector3.back;
                }
            }

            return direction;
        }
    }
}