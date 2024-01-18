using System;
using System.Collections.Generic;
using Monobehavior;
using StaticData;
using UnityEngine;

namespace Services
{
    public interface ILevelFruitCreator
    {
        public event Action OnLastTakingFruit;
        public List<IFruitCollidDetector> FruitList { get; }
        public void InitializeFruitsOnLevel(LevelStaticData levelStaticData);
        public void ClearLevel();
        public LevelStaticData CurrentLevelStaticData { get; }
    }
}