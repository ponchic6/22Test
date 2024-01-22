using UnityEngine;
using UnityEngine.UI;

namespace Monobehavior.UIButtonHandlers
{
    public class FramePositionSetter : MonoBehaviour
    {
        [SerializeField] private Image _frame;
    
        public void SetPosition()
        {
            _frame.transform.position = transform.position;
        }
    }
}
