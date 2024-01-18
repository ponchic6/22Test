namespace Handlers
{
    public interface IWinLossHandler
    {
        public void SubscribeOnTimeOver();
        public void SubscribeOnIncorrectChooseOfBasket();
    }
}