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

    public void SubscribeOnTimeOver()
    {
        _uiFactory.Timer.GetComponent<Timer>().OnTimeOver += ToLose;
    }

    public void SubscribeOnIncorrrectChooseOfBasket()
    {
        _tractorFactory.GetTractor().GetComponent<IFruitChecker>().OnCheckFruitType += TryToLose;
    }

    private void TryToLose(bool obj)
    {
        if (obj == false)
            ToLose();
    }

    private void ToLose()
    {
        _tractorFactory.DestroyTractor();
        _uiFactory.CreateLossDisplay();
    }
}