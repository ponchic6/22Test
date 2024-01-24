using Services;
using UnityEngine;

namespace Monobehavior
{
    public class TractorMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += Time.deltaTime * _speed * transform.forward;
        }
    }
}
