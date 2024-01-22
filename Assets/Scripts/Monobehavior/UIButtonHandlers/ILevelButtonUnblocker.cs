using StaticData;

namespace Monobehavior.UIButtonHandlers
{
    public interface ILevelButtonUnblocker
    {
        public void TryUnblockLevelButton();
        public void SetLevelStaticData(LevelStaticData levelStaticData);
    }
}