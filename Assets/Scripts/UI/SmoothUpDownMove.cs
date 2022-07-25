using System.Collections;
using UnityEngine;

[RequireComponent(typeof(NavigationArrow))]
public class SmoothUpDownMove : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    private NavigationArrow _arrow;
    private Vector3 _yPositionMax;
    private Vector3 _yPositionMin;

    private void Awake()
    {       
        _arrow = GetComponent<NavigationArrow>();
    }

    private void Start()
    {
        UpdateOfset(transform.position);
        StartCoroutine(ChangePosition());
    }

    private void OnEnable()
    {
        _arrow.WaypointChanged += UpdateOfset;
    }

    private void OnDisable()
    {
        _arrow.WaypointChanged -= UpdateOfset;
        StopCoroutine(ChangePosition());
    }
    private void UpdateOfset(Vector3 position)
    {
        _yPositionMax = new Vector3(position.x, position.y + _range, position.z);
        _yPositionMin = new Vector3(position.x, position.y + (-_range), position.z);
    }

    private IEnumerator ChangePosition()
    {
        while (enabled)
        {
            transform.position = Vector3.Lerp(_yPositionMax, _yPositionMin, Mathf.PingPong(Time.time * _speed, _range));
            yield return null;
        }
    }
}
