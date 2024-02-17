using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;

    private void Start()
    {
        StartCoroutine(S());
    }

    public IEnumerator S()
    {
        while (true)
        {
            _shootController.Shoot(new Vector3(0, 3, 0));
            yield return new WaitForSeconds(3f);
        }
        
    }
}
