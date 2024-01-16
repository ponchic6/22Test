using UnityEngine;
using Zenject;

public class LossHandler : ILossHandler
{
    private IUIFactory _uiFactory;
    private ITractorFactory _tractorFactory;

    public LossHandler(IUIFactory uiFactory, ITractorFactory tractorFactory)
    {
        _uiFactory = uiFactory;
        _tractorFactory = tractorFactory;
    }

    public void Initialize()
    {
        _uiFactory.Timer.GetComponent<Timer>().OnTimeOver += ToLose;
    }

    private void ToLose()
    {
        _tractorFactory.DestroyTractor();
        _uiFactory.CreateLossDisplay();
    }
}