using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyComponent : MonoBehaviour, IDamageable
{
    public delegate void KeyComponentDestroy();
    public static event KeyComponentDestroy OnKeyComponentDestroy;

    public int Health => _health;

    [SerializeField] private int _health;

    public void Damage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        OnKeyComponentDestroy?.Invoke();
        Destroy(gameObject);
    }
}
