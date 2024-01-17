using System;
using UnityEngine;

public class FruitCollidDetector : MonoBehaviour
{
    public event Action<GameObject> OnCollision;
    
    private void OnTriggerEnter(Collider other)
    {
        OnCollision?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
