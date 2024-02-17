using UnityEngine;

public class ShootController : MonoBehaviour, ICanShoot
{
    [SerializeField] private Bullet _bulletPrefab;
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
        bullet.transform.position = transform.position;
        bullet.Rigidbody.velocity = direction.normalized * _bulletSpeed;
    }
}
