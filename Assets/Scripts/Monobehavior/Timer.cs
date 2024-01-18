using System;
using TMPro;
using UnityEngine;

namespace Monobehavior
{
    public class Timer : MonoBehaviour, ITimer
    {
        public event Action OnTimeOver;

        [SerializeField] private float _maxTime;

        [SerializeField] private TMP_Text _timerText;

        private float _timer;

        private bool _isTimerOver;

        private void Awake()
        {
            _timer = _maxTime;
        }

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
    }
}
