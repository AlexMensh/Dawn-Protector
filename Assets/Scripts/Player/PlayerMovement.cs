using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _input;
    private float _horizontalInput;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {

    }
}
