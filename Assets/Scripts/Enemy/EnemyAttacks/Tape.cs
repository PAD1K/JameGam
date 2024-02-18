using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tape : EnemyDelayedAttack
{
    [SerializeField] private GameObject _warnTrajectoryPrefab;
    [SerializeField] private TapeDamage _damagePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _startSpeed;
    public static Tape Instance;
    private Vector3 _destination;

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
        _destination = new Vector3(40,0,-3);
    }

    public override void StartDelayedAttack()
    {
        StartCoroutine("WarnAndDamage");
    }
    IEnumerator WarnAndDamage()
    {
        Warn();
        yield return new WaitForSeconds(5f);
        Damage();
    }

    private void Warn()
    {
        Destroy(Instantiate(_warnTrajectoryPrefab, new Vector3(0,0,-3), new Quaternion()), 5f);
        Debug.Log("Warn");
    }

    private void Damage()
    {
        TapeDamage damageObject = Instantiate(_damagePrefab, new Vector3(-40,0,0),new Quaternion());
        Destroy(damageObject, 5f);
        damageObject.Rigidbody.AddForce(new Vector3(_speed,0,0), ForceMode.VelocityChange);
        Debug.Log("Damage");
    }
}
