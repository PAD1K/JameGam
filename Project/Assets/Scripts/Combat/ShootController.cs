using UnityEngine;

public class ShootController : MonoBehaviour, ICanShoot
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _weapon;
    [SerializeField] private int _prewarmBullets = 5;
    [SerializeField] private float _bulletSpeed = 5f;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _prewarmBullets);
    }

    public void Shoot(Vector3 direction)
    {
        Bullet bullet = _bulletPool.Get();
        bullet.transform.position = _weapon.position;
        bullet.transform.rotation = Quaternion.Euler(direction);
        bullet.Rigidbody.velocity = direction.normalized * _bulletSpeed;
        // Bullet bullet = new Bullet();
        // Debug.Log(_bulletPrefab);
        // Instantiate(_bulletPrefab, _weapon.transform.position, Quaternion.identity);
        // Debug.Log(_bulletPrefab);

        // _bulletPrefab.Rigidbody.velocity = direction.normalized * _bulletSpeed;
    }
}
