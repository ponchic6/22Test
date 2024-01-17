using System.Collections;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}