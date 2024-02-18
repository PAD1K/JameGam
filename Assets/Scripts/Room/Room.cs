using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Room : MonoBehaviour, IRoomable
{
    [SerializeField] private List<GameObject> _itemsToHide = new List<GameObject>();
    [SerializeField] private GameObject _picture;
    [SerializeField] private GameObject _internalWall;
    private Vector3 _defaultPosition;   

    private void Awake() 
    {
        _defaultPosition = transform.position;
        _picture?.SetActive(false);
    }
    public void Hide()
    {
        foreach(GameObject item in _itemsToHide)
        {
            item.SetActive(false);
        }
        _internalWall.SetActive(true);
    }

    public void Reveal()
    {
        foreach(GameObject item in _itemsToHide)
        {
            item.SetActive(true);
        }
        _internalWall.SetActive(false);
        transform.position = Vector3.zero;
    }
}
