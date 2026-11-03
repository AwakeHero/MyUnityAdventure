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
    private float _minDistanceToPlayer = 3f;
    [SerializeField] private Vector3 _playerPosition;

    private void Awake()
    {
        _targetsPosition = new Queue<Vector3>();

        foreach(Transform target in _targets)
            _targetsPosition.Enqueue(target.position);
        SwitchTarget();
    } 
    private void Update()
    {
        Vector3 directionToTarget = _currentTarget - transform.position;
        Vector3 directionToPlayer = _playerPosition - transform.position;
        if (IsPlayerDetected(directionToPlayer))
        {
            if (directionToTarget.magnitude <= _minDistanceToTarget) SwitchTarget();
            Vector3 normalizedDirection = directionToTarget.normalized;
            ProcessMoveTo(normalizedDirection);
            ProcessRotateTo(normalizedDirection);
        }
        else
        {
            Vector3 normalizedDirection = directionToPlayer.normalized;
            ProcessMoveTo(normalizedDirection);
            ProcessRotateTo(normalizedDirection);
        }
        
    }

    private bool IsPlayerDetected(Vector3 directionToPlayer)
    {
        return directionToPlayer.magnitude <= _minDistanceToPlayer;
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction, Color.magenta);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        transform.LookAt(_currentTarget);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPosition.Dequeue();
        _targetsPosition.Enqueue(_currentTarget); 
    }
}
