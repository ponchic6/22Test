using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Services
{
    public class LevelsStaticDataService : ILevelsStaticDataService
    {
        private List<LevelStaticData> _levelConfigsList;
        
        public List<LevelStaticData> LevelConfigsList => _levelConfigsList;

        public void FillConfigLevelList(List<LevelStaticData> list)
        {
            _levelConfigsList = list;
        }
    }
}