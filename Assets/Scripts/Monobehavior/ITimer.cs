﻿using System;

namespace Monobehavior
{
    public interface ITimer
    {
        public event Action OnTimeOver;
        public void DisableTimer();
    }
}