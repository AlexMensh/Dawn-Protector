using System;
using UnityEngine;

public class EnemiesMover : MonoBehaviour
{
    [SerializeField] private float _stepDistance = 1f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private PlayerAttack _player;

    private bool _shouldMove = false;
    private Vector3 _targetPosition;

    public event Action TurnFinished;
        
    private void Update()
    {
        if (_shouldMove)
        {
            MoveForward();
        }
    }

    public void AllowMove()
    {
        _shouldMove = true;
        _targetPosition = transform.position + transform.forward * _stepDistance;
    }

    private void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _shouldMove = false;
            TurnFinished?.Invoke();
            _player.AllowShoot();
        }
    }
}