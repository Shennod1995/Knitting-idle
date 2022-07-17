using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private BallOfYarnFactory _yarnFactory;
    [SerializeField] private FabricFactory _fabricFactory;
    [SerializeField] private BraFactory _braFactory;
    [SerializeField] private Player _player;

    private int _currentWayoint = 0;

    private void OnEnable()
    {
        _yarnFactory.Spawned += OnWaypointChange;
        _fabricFactory.Spawned += OnWaypointChange;
        _braFactory.Spawned += OnWaypointChange;
        _player.ItemTaken += OnWaypointChange;
    }

    private void OnDisable()
    {
        _yarnFactory.Spawned -= OnWaypointChange;
        _fabricFactory.Spawned -= OnWaypointChange;
        _braFactory.Spawned -= OnWaypointChange;
        _player.ItemTaken -= OnWaypointChange;
    }

    private void OnWaypointChange()
    {
        if (_waypoints != null)
        {
            _currentWayoint++;
            StartCoroutine(MoveToWaypoint(NextWaypoint()));
        }
    }

    private IEnumerator MoveToWaypoint(Transform waypoint)
    {
        transform.position = waypoint.position;
        yield return null;
    }

    private Transform NextWaypoint()
    {
        if (_currentWayoint > _waypoints.Count)
            _currentWayoint = 0;
            return _waypoints[_currentWayoint];
    }
}
