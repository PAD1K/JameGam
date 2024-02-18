using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour, IDamageable
{
    public delegate void EnemyChangeState();
    public static event EnemyChangeState OnEnemyChangeState;

    [SerializeField] private float _moveTime;
    [SerializeField] private float _attackTime;
    public int Health
    {
       get
       {
           return _health;
       }
    }
    public float MoveTime
    {
        get { return _moveTime;}
    }
    public float AttackTime
    {
        get { return _attackTime;}
    }
    private int _health = 300;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        if(_health < 0)
        {
            return;
        }
        if(damage < 0)
        {
            damage = 0;
        }

        _health -= damage;

        if (_health % 100 == 0)
        {
            OnEnemyChangeState?.Invoke();
        }

        if(_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
}
