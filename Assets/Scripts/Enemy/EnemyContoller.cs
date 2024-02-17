using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour, IDamageable
{
    [SerializeField] private float _moveTime;
    [SerializeField] private float _attackTime;
    public int Health => _health;
    public float MoveTime => _moveTime;
    public float AttackTime => _attackTime;
    private int _health;


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
