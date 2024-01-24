using System;

namespace Monobehavior.UIView
{
    public interface ITimer
    {
        public event Action OnTimeOver;
        public void DisableTimer();
        public void SetTimer(int seconds);
    }
}