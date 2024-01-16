using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    public Action OnTimeOver;
    
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
            gameObject.SetActive(false);
        }
    }
}
