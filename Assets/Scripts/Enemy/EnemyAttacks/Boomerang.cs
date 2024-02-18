using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Boomerang : EnemyAttack
{
    public static Boomerang Instance;
    public override void StartAttack(Vector3 direction)
    {
        Debug.Log("Start Boomerang");
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
}
