using System;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    public event Action OnCollision;
    
    private void OnTriggerEnter(Collider other)
    {
        OnCollision?.Invoke();
        Destroy(gameObject);
    }
}
