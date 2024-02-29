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
    // public Animator PlayerAnimator => _playerAnimator = value;
    public Animator PlayerAnimator
    {
        set => _playerAnimator = value;
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
        if(direction != Vector3.zero)
        {
            if(direction.x > 0 && direction.y == 0)
            {
                _spriteRenderer.flipX = false;
            }
            if(direction.x < 0 && direction.y == 0)
            {
                _spriteRenderer.flipX = true;
            }
            _playerAnimator.SetBool("IsWalking", true);
            _playerAnimator.SetFloat("DirX", direction.x);
            _playerAnimator.SetFloat("DirY", direction.y);
        }
        else
        {
            _playerAnimator.SetBool("IsWalking", false);
        }
        if (_movementSpeed < 0)
        {
            _movementSpeed = 0;
        }
        //PlayAnimation(direction);
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
        _playerAnimator.SetTrigger("Dashed");
    }

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _spriteRenderer = _playerAnimator.GetComponent<SpriteRenderer>();
    }
}
