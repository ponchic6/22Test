using System;
using UnityEngine;

namespace Services
{
    public class InputService : IInputService
    {
        public event Action<Vector3> OnSwipe;
        public event Action OnRightClockDown;
        public event Action OnRightClockUp;

        private const float Eps = 10;
        
        private bool _canSwipe;
        private Vector3 _startMousePos;

        public InputService(ITickService tickService)
        {
            tickService.OnTick += CheckSwipe;
            tickService.OnTick += CheckTouch;
            tickService.OnTick += CheckRightClickDown;
            tickService.OnTick += CheckRightClickUp;
        }

        private void CheckRightClickUp()
        {
            if (Input.GetMouseButtonUp(1))
            {
                OnRightClockUp?.Invoke();
            }
        }

        private void CheckRightClickDown()
        {
            if (Input.GetMouseButtonDown(1))
            {
                OnRightClockDown?.Invoke();
            }
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
                
                Camera camera = Camera.main;
                Ray startRay = camera.ScreenPointToRay(_startMousePos);
                Ray endRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHitStart;
                RaycastHit raycastHitEnd;

                Vector3 direction = new Vector3();

                if (Physics.Raycast(startRay, out raycastHitStart, Mathf.Infinity, LayerMask.GetMask("Ground")) &&
                    Physics.Raycast(endRay, out raycastHitEnd, Mathf.Infinity, LayerMask.GetMask("Ground")))
                {
                    direction = raycastHitEnd.point - raycastHitStart.point;
                }

                direction = ToRoundVector3(direction);
                OnSwipe?.Invoke(direction);
            }
        }

        private Vector3 ToRoundVector3(Vector3 direction)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
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
                if (direction.z > 0)
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