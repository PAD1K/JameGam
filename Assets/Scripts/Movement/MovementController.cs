using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable
{
    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rigidbody;

    /// <summary>
    /// Перемещает объект в указанном направлении с учетом скорости движения.
    /// </summary>
    /// <param name="direction">Направление движения в виде вектора Vector3.</param>
    public void Move(Vector3 direction)
    {
        if (float.IsNaN(_movementSpeed))
        {
            return;
        }

        if (_movementSpeed < 0)
        {
            _movementSpeed = 0;
        }

        _rigidbody.AddForce(direction * _movementSpeed, ForceMode.VelocityChange);
    }

    private void Awake()
    {
        _movementSpeed = 0;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }
}
