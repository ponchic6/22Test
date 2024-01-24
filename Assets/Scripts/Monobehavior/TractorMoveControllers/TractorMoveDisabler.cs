using UnityEngine;

namespace Monobehavior
{
    public class TractorMoveDisabler : MonoBehaviour, ITractorMoveDisabler
    {
        [SerializeField] private TractorMover _tractorMover;
        [SerializeField] private TractorDirectionChanger _tractorDirectionChanger;

        public void DisableMove()
        {
            _tractorMover.enabled = false;
            _tractorDirectionChanger.enabled = false;
        }
    }
}
