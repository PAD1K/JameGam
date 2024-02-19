using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{ 
    public int Health
    { 
        get{ return _health; }
    }
    [SerializeField] private int _health;
    private int _currentSpriteNumber = 0;
    private Animator[] _playerAnimations;
    private MovementController _movementController;

    /// <summary>
    /// Наносит урон объекту.
    /// </summary>
    /// <param name="damage">Количество урона, которое нужно нанести.</param>
    public void Damage (int damage)
    {
        // Проверка на то, что урон нельзя нанести уже мертвому объекту.
        if (_health <= 0)
        {
            return;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }
    
    /// <summary>
    /// Обрабатывает смерть объекта.
    /// </summary>
    public void Death()
    {
        gameObject.SetActive(false);
        
        // TODO: анимация смерти
    }

    private void Awake() 
    {
        _playerAnimations = GetComponentsInChildren<Animator>();
        if (_playerAnimations == null)
        {
            Debug.LogWarning("Animations is not set");
            return;
        }

        _movementController = GetComponent<MovementController>();
        if (_movementController == null)
        {
            Debug.LogWarning("Movement Controller is not set");
            return;
        }

        foreach (Animator animation in _playerAnimations)
        {
            animation.gameObject.SetActive(false);
        }

        // Первый в списке аниматор является активным по умолчанию. 
        _playerAnimations[0].gameObject.SetActive(true);
        
        EnemyContoller.OnEnemyChangeState += ChangeSprite;
    }

    public void ChangeSprite()
    {
        // Если спрайт последний
        if (_currentSpriteNumber >= _playerAnimations.Length - 1)
        {
            return;
        }

        _playerAnimations[_currentSpriteNumber].gameObject.SetActive(false);
        _currentSpriteNumber++;
        _playerAnimations[_currentSpriteNumber].gameObject.SetActive(true);
        _movementController.PlayerAnimator = _playerAnimations[_currentSpriteNumber];
    }
}