using Factories;
using Monobehavior;

namespace Handlers
{
    public class LossHandler : ILossHandler
    {
        private readonly IUIFactory _uiFactory;
        private readonly ITractorFactory _tractorFactory;
        private bool _isLossed;

        public LossHandler(IUIFactory uiFactory, ITractorFactory tractorFactory)
        {
            _uiFactory = uiFactory;
            _tractorFactory = tractorFactory;
        }

        public void SubscribeOnTimeOver()
        {
            _uiFactory.Timer.GetComponent<ITimer>().OnTimeOver += ToLose;
        }

        public void SubscribeOnIncorrectChooseOfBasket()
        {
            _tractorFactory.GetTractor().GetComponent<IFruitChecker>().OnCheckFruitType += TryToLose;
        }

        public void UpdateLossStatus()
        {
            _isLossed = false;
        }

        private void TryToLose(bool obj)
        {
            if (obj == false)
                ToLose();
        }

        private void ToLose()
        {
            if (!_isLossed)
            {
                _tractorFactory.DestroyTractor();
                _uiFactory.CreateLossDisplay();
                _isLossed = true;
            }
        }
    }
}