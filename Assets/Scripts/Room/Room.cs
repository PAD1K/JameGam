using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Room : MonoBehaviour, IRoomable
{
    [SerializeField] private GameObject _items;
    [SerializeField] private GameObject _picture;
    private Vector3 _defaultPosition;   

    private void Awake() 
    {
        _defaultPosition = transform.position;
        _picture?.SetActive(false);
    }
    public void Hide()
    {
        _items.SetActive(false);

        Debug.Log($"Hide {gameObject}");
    }

    public void Reveal()
    {
        _items.SetActive(true);

        transform.position = Vector3.zero;
        Debug.Log($"Reveal {gameObject}");
    }
}
