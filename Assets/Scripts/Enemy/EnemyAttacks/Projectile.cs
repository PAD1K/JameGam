using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : EnemyAttack, ICanShoot
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _bulletSpeed = 5f;
     public static Projectile Instance;
    public override void StartAttack(Vector3 direction)
    {
        Debug.Log("Start Projectile");
        Shoot(direction);
    }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector3 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _weapon.transform);
        bullet.transform.position = _weapon.position;
        bullet.transform.rotation = Quaternion.Euler(direction);
        bullet.Rigidbody.velocity = direction.normalized * _bulletSpeed;
    }
}
