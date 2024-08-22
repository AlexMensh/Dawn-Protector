using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _))
        {
            Debug.Log("GameOver");
        }
    }
}
