using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryDrawer : MonoBehaviour
{
    [SerializeField] private BulletSpawnPoint _spawnPosition;
    [SerializeField] private Aim _aim;
    [SerializeField] private int numberOfPoints = 50;
    [SerializeField] private float lenght = 10f;
    [SerializeField] private LayerMask wallLayer;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
    }

    void Update()
    {
        DisplayTrajectory();
    }

    void DisplayTrajectory()
    {
        Vector3 direction = (_aim.transform.position - _spawnPosition.transform.position).normalized;
        Vector3 currentPosition = _spawnPosition.transform.position;
        float remainingLength = lenght;

        lineRenderer.SetPosition(0, currentPosition);

        for (int i = 1; i < numberOfPoints; i++)
        {
            RaycastHit hit;
            Physics.Raycast(currentPosition, direction, out hit, remainingLength, wallLayer);

            if (hit.collider != null)
            {
                lineRenderer.SetPosition(i, hit.point);
                
                direction = Vector3.Reflect(direction, hit.normal);

                remainingLength -= Vector3.Distance(currentPosition, hit.point);
                currentPosition = hit.point;
            }
            else
            {
                currentPosition += direction * (remainingLength / (numberOfPoints - i));
                lineRenderer.SetPosition(i, currentPosition);
            }
        }
    }
}