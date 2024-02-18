using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IMovable _playerMovement;
    private ICanShoot _playerShooting;

    private PlayerInput _playerInput;

    private Vector2 _lastDirection;

    // Start is called before the first frame update
    private void Awake() 
    {
        _playerInput = new PlayerInput();

        _playerInput.Movement.Enable();
        _playerInput.Combat.Enable();

        if(!TryGetComponent<IMovable>(out _playerMovement))
        {
            Debug.Log("There Is No IMovable object");
        }

        if(!TryGetComponent<ICanShoot>(out _playerShooting))
        {
            Debug.Log("There Is No ICanShoot object");
        }

        _playerInput.Combat.Shoot.started += ProcessShoot;
        _playerInput.Movement.Dash.started += ProcessDash;
    }

    private void ProcessDash(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _playerMovement.Dash(_lastDirection);
    }

    private void ProcessShoot(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Shoot();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 inputVector = _playerInput.Movement.MovementDirection.ReadValue<Vector2>();
        if(inputVector != Vector2.zero)
        {
            _lastDirection = inputVector;
        }
        _playerMovement.Move(inputVector);
    }

    private void Shoot()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(_playerInput.Combat.MousePosition.ReadValue<Vector2>());
        direction = direction - (Vector2)transform.position;
        _playerShooting.Shoot(direction.normalized);
    }

    private void OnDestroy() 
    {
        _playerInput.Combat.Shoot.started -= ProcessShoot;
    }
}
