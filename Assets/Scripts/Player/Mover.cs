using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField][Range(1, 20)] private float _speed;
    [SerializeField] private float _horizontalSpeed;
    [Space]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [Space]
    [SerializeField] private Rigidbody _rigidbody;
    
    private float _horizontal;
    private Vector3 _movementHorizontal;
    private Vector3 _movementForward;
    
    public void MovementLogic(float value)
    {
        _horizontal = value;
        _movementHorizontal = new Vector3(_horizontal * _horizontalSpeed, 0, _speed);
        _movementForward = new Vector3(0, 0, _speed);

        if (transform.position.x <= _minX && value < 0 || transform.position.x >= _maxX && value > 0)
        {
            _rigidbody.MovePosition(transform.position + _movementForward * Time.fixedDeltaTime);
        }
        else
        {
            _rigidbody.MovePosition(transform.position + _movementHorizontal * Time.fixedDeltaTime);
        }
    }

    public void StopMoving()
    {
        _speed = 0;
        _horizontalSpeed = 0;
    }
}