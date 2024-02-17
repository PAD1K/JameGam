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
}
