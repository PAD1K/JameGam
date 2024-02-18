using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Boomerang : EnemyAttack
{
    [SerializeField] private BoomerangBullet _bulletPrefab;
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _bulletSpeed = 5f;
    public static Boomerang Instance;
    public override void StartAttack(Vector3 direction)
    {
        Debug.Log("Start Boomerang");
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
        BoomerangBullet bullet = Instantiate(_bulletPrefab, _weapon.transform);
        bullet.transform.position = _weapon.position;
        bullet.transform.rotation = Quaternion.Euler(direction);
        bullet.Rigidbody.velocity = direction.normalized * _bulletSpeed;
    }
}
