using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Player _player;

    private int _currentWayoint = 0;

    public event UnityAction<Vector3> WaypointChanged;

    private void Start()
    {
        WaypointChanged?.Invoke(_waypoints[_currentWayoint].position);
    }

    private void OnEnable()
    {
        _player.ItemTaken += OnWaypointChange;
        _player.ItemGiven += OnWaypointChange;
    }

    private void OnDisable()
    {
        _player.ItemTaken -= OnWaypointChange;
        _player.ItemGiven -= OnWaypointChange;
    }

    private void OnWaypointChange()
    {
        if (_waypoints != null)
        {
            StartCoroutine(MoveToWaypoint(GetNextWaypoint()));
        }
    }

    private IEnumerator MoveToWaypoint(Transform waypoint)
    {
        WaypointChanged?.Invoke(waypoint.position);
        transform.position = waypoint.position;
        yield return null;
    }

    private Transform GetNextWaypoint()
    {
        _currentWayoint++;
        if (_currentWayoint > _waypoints.Count -1)
            _currentWayoint = 0;

        return _waypoints[_currentWayoint];
    }
}
