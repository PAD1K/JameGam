using UnityEngine;

public class Bullet : MonoBehaviour, IObjectPoolElement<Bullet>
{
    [SerializeField] private int _bulletDamage = 5;
    public Rigidbody Rigidbody { get; private set; }
    private ObjectPool<Bullet> _objectPool;

    public void SetObjectPool(ObjectPool<Bullet> objectPool)
    {
        _objectPool = objectPool;
    }

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            Debug.LogError($"Set Rigidbody2D on object {gameObject.name}");
            return;
        }
        
        Rigidbody = rigidbody;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if(!collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyController) &&
            !collision.gameObject.TryGetComponent<Stats>(out Stats stats))
        {
            ReleaseBullet();
            return;
        }

        if(enemyController != null)
        {
            enemyController.Damage(_bulletDamage);
        }

        if (stats != null)
        {
            stats.Damage(_bulletDamage);
        }

        ReleaseBullet();*/
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log($"Damage: {_bulletDamage}");
            ReleaseBullet();
        }
    }

    private void ReleaseBullet()
    {
        _objectPool.Release(this);
    }
}
