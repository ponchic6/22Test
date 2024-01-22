using System.Collections.Generic;
using StaticData;

namespace Services
{
    public interface ILevelsStaticDataService
    {
        public void FillConfigLevelList(List<LevelStaticData> list);
        public List<LevelStaticData> LevelConfigsList { get; }
    }
}