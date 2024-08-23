using System;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public event Action PlayerLost;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            PlayerLost?.Invoke();
        }
    }
}