using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Room : MonoBehaviour, IRoomable
{
    // Start is called before the first frame update
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Reveal()
    {
        gameObject.SetActive(true);

    }
}
