using System.Collections.Generic;
using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _agroDistance;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private List<Transform> _targets;
    private Queue<Vector3> _targetsPosition;
    private Vector3 _currentTarget;
    private float _minDistanceToTarget = 0.3f;


    private void Awake()
    {
        _targetsPosition = new Queue<Vector3>();

        foreach(Transform target in _targets)
            _targetsPosition.Enqueue(target.position);
        SwitchTarget();
    } 

    private Vector3 GetDirectionToHero() => _playerPosition.position - transform.position;
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
        ProcessRotateTo(direction);
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
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPosition.Dequeue();
        _targetsPosition.Enqueue(_currentTarget); 
    }
}
