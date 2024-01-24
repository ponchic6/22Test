using System;
using TMPro;
using UnityEngine;

namespace Monobehavior.UIView
{
    public class Timer : MonoBehaviour, ITimer
    {
        public event Action OnTimeOver;
        
        [SerializeField] private TMP_Text _timerText;

        private float _timer;

        private bool _isTimerOver;
        
        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _timerText.text = Math.Truncate(_timer).ToString();
            }

            else
            {
                OnTimeOver?.Invoke();
                DisableTimer();
            }
        }

        public void DisableTimer()
        {
            gameObject.SetActive(false);
        }

        public void SetTimer(int seconds)
        {
            _timer = seconds;
        }
    }
}
