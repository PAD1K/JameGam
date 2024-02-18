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
            _shootController.Shoot(new Vector3(3, 0, 0));
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
