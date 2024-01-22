using System;

namespace Monobehavior.View
{
    public interface ITimer
    {
        public event Action OnTimeOver;
        public void DisableTimer();
    }
}