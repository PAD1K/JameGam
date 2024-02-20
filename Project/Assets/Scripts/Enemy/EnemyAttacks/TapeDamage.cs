using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeDamage : MonoBehaviour
{
    [SerializeField] private int _tapeDamage = 5;
    public Rigidbody Rigidbody { get; private set; }
    void Awake()
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
            target.Damage(_tapeDamage);
        }
        Destroy(gameObject);
    }
}
