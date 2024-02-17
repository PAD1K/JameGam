using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour, IShootable, IDamageable
{
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
        set { _moveTime = value;}
    }
    public float AttackTime
    {
        get { return _attackTime;}
        set { _attackTime = value;}
    }
    private int _health;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 direction)
    {

    }

    public void Damage(int damage)
    {

    }
}
