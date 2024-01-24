using Enums;
using UnityEngine;

namespace Monobehavior.Fruits
{
    public class FruitType : MonoBehaviour
    {
        [SerializeField] private FruitsEnum _type;

        public FruitsEnum GetFruitType => _type;
    }
}
