using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _pathContainer;

    private Transform[] _path;
    private Transform _nextWaypoint;
    private int _nextWaypointIndex;

    private void Start()
    {
        CreatePath();

        _nextWaypoint = _path[0];
        transform.position = _path[0].position;
    }

    private void Update()
    {
        LookAtWaypoint(_nextWaypoint);
        MoveToWaypoint(_nextWaypoint);
    }

    private void CreatePath()
    {
        _path = new Transform[_pathContainer.childCount];

        for (int i = 0; i < _pathContainer.childCount; i++)
        {
            _path[i] = _pathContainer.GetChild(i);
        }
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _moveSpeed * Time.deltaTime);

        if (transform.position == waypoint.position)
            UpdateNextWaypoint();
    }

    private void UpdateNextWaypoint()
    {
        _nextWaypointIndex++;

        if (_nextWaypointIndex >= _path.Length)
            _nextWaypointIndex = 0;

        _nextWaypoint = _path[_nextWaypointIndex];
    }

    private void LookAtWaypoint(Transform waypoint)
    {
        Vector3 directionToWaypoint = waypoint.position - transform.position;

        if (directionToWaypoint == Vector3.zero)
            return;

        transform.forward = directionToWaypoint;
    }
}
