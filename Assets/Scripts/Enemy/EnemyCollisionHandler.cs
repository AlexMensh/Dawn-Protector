using System;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    
    private EnemyHealth _enemyHealth;
    
    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            _bulletSpawner.RemoveObject(bullet);
            _enemyHealth.ApplyDamage(bullet.Damage);
        }
    }
}