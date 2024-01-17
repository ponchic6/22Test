namespace Handlers
{
    public interface ILossHandler
    {
        public void SubscribeOnTimeOver();
        public void SubscribeOnIncorrectChooseOfBasket();
        public void UpdateLossStatus();
    }
}