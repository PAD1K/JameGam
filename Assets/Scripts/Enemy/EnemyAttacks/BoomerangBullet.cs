using System.Collections;
using UnityEngine;

public class BoomerangBullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 5;
    public Rigidbody Rigidbody { get; private set; }
    private void Awake()
    {
        if (!TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            Debug.LogError($"Set Rigidbody2D on object {gameObject.name}");
            return;
        }
        
        StartCoroutine("TurnBack");
        Rigidbody = rigidbody;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable target;
        if(collision.transform.TryGetComponent<IDamageable>(out target) && collision.gameObject.tag != "Enemy")
        {
            target.Damage(_bulletDamage);
        }
        Destroy(gameObject);
    }

    IEnumerator TurnBack()
    {
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Aboba");
        Rigidbody.velocity = -Rigidbody.velocity;
    }
}
