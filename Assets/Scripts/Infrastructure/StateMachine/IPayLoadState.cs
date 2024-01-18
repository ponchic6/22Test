namespace Infrastructure.StateMachine
{
    public interface IPayLoadState<TPayLoad, NPayLoad> : IExitableState
    {
        public void Enter(TPayLoad payLoad, NPayLoad otherPayLoad);
    }
}