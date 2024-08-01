using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Camera _camera;

    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
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
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            Vector3 direction = targetPoint - _spawnPoint.position;

            Bullet bullet = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            bullet.SetDirection(direction);
        }
    }
}