using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(fileName = "PathStaticData")]
    public class PathStaticData : ScriptableObject
    {
        [SerializeField] private UIPathStaticData _uiPathStaticData;
        public UIPathStaticData UIPathStaticData => _uiPathStaticData;
    }
}