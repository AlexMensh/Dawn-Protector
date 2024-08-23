using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _yRotationLimit;
    
    private PlayerInput _playerInput;
    private const float _fullAngle = 360f;
    private const float _fullAngleHalf = 180f;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    
    private void Update()
    {
        if (_playerInput.IsActive)
            PlayerRotation();
    }

    private void PlayerRotation()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;

            targetPoint.y = transform.position.y;

            Vector3 direction = targetPoint - transform.position;
            Vector3 invertedTarget = transform.position - direction;

            Quaternion targetRotation = Quaternion.LookRotation(invertedTarget - transform.position);
            Vector3 targetEulerAngles = targetRotation.eulerAngles;

            if (targetEulerAngles.y > _fullAngleHalf)
            {
                targetEulerAngles.y -= _fullAngle;
            }

            float clampedY = Mathf.Clamp(targetEulerAngles.y, -_yRotationLimit, _yRotationLimit);

            transform.rotation = Quaternion.Euler(targetEulerAngles.x, clampedY, targetEulerAngles.z);
        }
    }
}