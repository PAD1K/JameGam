using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KeyComponent : MonoBehaviour, IKeyable, IDamageable
{
    public delegate void DeathHandler();
    public static event DeathHandler OnDeath;
    public int Health => _health;
    [SerializeField] private Stats _stats;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _gameObject;

    public void InstantiateComponent(Vector3 position)
    {
        Instantiate(_gameObject, position, Quaternion.identity);
    }

    /// <summary>
    /// Наносит урон объекту.
    /// </summary>
    /// <param name="damage">Количество урона, которое нужно нанести.</param>
    public void Damage(int damage)
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
        OnDeath?.Invoke();

        // TODO: анимация смерти
    }
}
