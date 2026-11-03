using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Queue<Vector3> _targetsPosition;
    private Vector3 _currentTarget;
    private float _minDistanceToTarget = 0.05f;
    private float _agroDistance = 3f;
    [SerializeField] private Vector3 _playerPosition;

    private void Awake()
    {
        _targetsPosition = new Queue<Vector3>();

        foreach(Transform target in _targets)
            _targetsPosition.Enqueue(target.position);
        SwitchTarget();
    } 

    private Vector3 GetDirectionToHero() => _playerPosition - transform.position;
    private Vector3 GetDirectionToTarget() => _currentTarget - transform.position;
    private void Update()
    {
        Vector3 direction = GetDirectionToHero();

        if (!IsPlayerDetected())
        {
            direction = GetDirectionToTarget();
            if (direction.magnitude <= _minDistanceToTarget) SwitchTarget();
        }
        ProcessMoveTo(direction.normalized);
        ProcessRotateTo(direction.normalized);
    }
    
    private bool IsPlayerDetected()
    {
        return GetDirectionToHero().magnitude <= _agroDistance;
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction, Color.magenta);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        transform.LookAt(_currentTarget * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPosition.Dequeue();
        _targetsPosition.Enqueue(_currentTarget); 
    }
}
