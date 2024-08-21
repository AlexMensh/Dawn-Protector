using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            _bulletSpawner.RemoveObject(bullet);
            Destroy(gameObject);    
        }
    }
}