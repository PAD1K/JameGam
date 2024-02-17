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

    public void Damage (int damage)
    {
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

    public void Death()
    {
        gameObject.SetActive(false);
        
        // TODO: анимация смерти
    }
}
