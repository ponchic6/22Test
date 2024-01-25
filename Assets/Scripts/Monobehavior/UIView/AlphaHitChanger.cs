using UnityEngine;
using UnityEngine.UI;

namespace Monobehavior.UIView
{
    public class AlphaHitChanger : MonoBehaviour
    {
        [SerializeField] private Image _ring;

        private void Awake()
        {
            _ring.alphaHitTestMinimumThreshold = 1f;
        }
    }
}
