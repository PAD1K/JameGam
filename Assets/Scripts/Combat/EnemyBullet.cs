using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 5;
    public Rigidbody Rigidbody { get; private set; }
    //private ObjectPool<EnemyBullet> _objectPool;

    // public void SetObjectPool(ObjectPool<EnemyBullet> objectPool)
    // {
    //     _objectPool = objectPool;
    // }

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
        IDamageable target;
        if(collision.transform.TryGetComponent<IDamageable>(out target))
        {
            target.Damage(_bulletDamage);
        }
        //ReleaseBullet();
        Destroy(gameObject);
    }

    private void ReleaseBullet()
    {
        //_objectPool?.Release(this);
    }
}
