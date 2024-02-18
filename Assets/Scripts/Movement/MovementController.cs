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
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private string[] _animationName;
    private Rigidbody _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private string _currentAnimation;

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
        PlayAnimation(direction);
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
        _spriteRenderer = _playerAnimator.GetComponent<SpriteRenderer>();
    }

    private void PlayAnimation(Vector3 direction)
    {
        if(direction.y == 0 && direction.x == 0)
        {
            _playerAnimator.Play(_currentAnimation);
        }
        if(direction.y < 0)
        {
            _currentAnimation = "down";
            _playerAnimator.Play("run " + _currentAnimation);
        }
        if(direction.y > 0)
        {
            _currentAnimation = "up";
            _playerAnimator.Play("run " + _currentAnimation);
        }
        if(direction.x > 0 && direction.y == 0)
        {
            _currentAnimation = "right";
            _spriteRenderer.flipX = false;
            _playerAnimator.Play("run " + _currentAnimation);
        }
        if(direction.x < 0 && direction.y == 0)
        {
            _currentAnimation = "right";
            _spriteRenderer.flipX = true;
            _playerAnimator.Play("run " + _currentAnimation);
        }
    }
}
