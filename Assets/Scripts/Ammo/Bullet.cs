using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}