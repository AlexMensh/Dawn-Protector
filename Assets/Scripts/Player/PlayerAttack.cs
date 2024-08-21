using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(BulletSpawner))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BulletSpawnPoint _spawnPoint;
    [SerializeField] private Aim _aim;

    private BulletSpawner _spawner;
    private PlayerInput _input;
    private float _shotForce = 20;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _spawner = GetComponent<BulletSpawner>();
    }

    private void Update()
    {
        if (_input.GetAttackInput())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 direction = _aim.transform.position - _spawnPoint.transform.position;

        Bullet bullet = _spawner.SpawnObject(_spawnPoint.transform.position);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.AddForce(direction * _shotForce, ForceMode.Impulse);
    }
}