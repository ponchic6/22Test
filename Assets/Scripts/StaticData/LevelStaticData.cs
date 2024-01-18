using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(fileName = "LevelStaticData")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private List<Vector3Int> _fruitPos;
        [SerializeField] private List<FruitsEnum> _fruitsEnums;
        [SerializeField] private string _levelName;
        [SerializeField] private int _rewardForLevel;

        public int RewardForLevel => _rewardForLevel;
        public List<Vector3Int> FruitsPos => _fruitPos;
        public List<FruitsEnum> FruitsEnums => _fruitsEnums;
        public string LevelName => _levelName;
        public bool IsLevelUnblock;
    }
}