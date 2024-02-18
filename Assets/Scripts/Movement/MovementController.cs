using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour, IMovable
{
    public float MovementSpeed
    {
        get { return _movementSpeed; }
    }
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _dashForce;
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

        Vector3 currentVelocity = _rigidbody.velocity;
        Vector3 targetVelocity = new Vector3(direction.x,direction.y,0);
        targetVelocity *= _movementSpeed;
        Vector3 VelocityChange = targetVelocity - currentVelocity;
        _rigidbody.AddForce(VelocityChange, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Делает рывок в указанном направлении с учетом скорости рывка.
    /// </summary>
    /// <param name="direction">Направление движения в виде вектора Vector3.</param>
    public void Dash(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _dashForce, ForceMode.VelocityChange);
    }

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }
}
