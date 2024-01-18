using System.Collections.Generic;
using StaticData;

namespace Services
{
    public interface ILevelStaticDataService
    {
        public void FillConfigLevelList(List<LevelStaticData> list);
        public List<LevelStaticData> LevelConfigsList { get; }
    }
}