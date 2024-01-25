using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Monobehavior.Fruits
{
    public class FruitIdleMover : MonoBehaviour
    {
        private Tween _rotateTween;
        private Tween _jumpTween;

        private float _jumpCooldown;
        private float _jumpHeight;
        
        private void Start()
        {
            _jumpCooldown = Random.Range(1f, 3f);
            _jumpHeight = Random.Range(0.2f, 0.7f);

            _rotateTween = DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 180, 0), 1).SetEase(Ease.Linear))
                .Append(transform.DORotate(new Vector3(0, 360, 0), 1).SetEase(Ease.Linear)).SetLoops(-1);

            _jumpTween = DOTween.Sequence().Append(_jumpTween = transform.DOJump(transform.position, _jumpHeight, 1, 1))
                .AppendInterval(_jumpCooldown).SetLoops(-1);
        }

        private void OnDestroy()
        {
            _rotateTween.Kill();
            _jumpTween.Kill();
        }
    }
}
