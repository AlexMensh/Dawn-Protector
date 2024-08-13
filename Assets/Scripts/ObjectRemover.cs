using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletSpawner.RemoveObject(bullet);
        }
    }
}