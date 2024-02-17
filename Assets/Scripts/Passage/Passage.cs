using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour, IInteractable, IPassage
{
    public delegate void PassageActivted(IPassage passage);
    public static event PassageActivted OnPassageActivated;

    public IRoomable Room => _roomObj;
    public String Type => _type;

    [SerializeField] private GameObject _room;
    [SerializeField] private String _type;
    [SerializeField] private IRoomable _roomObj;

    private void Awake() 
    {
        _roomObj = _room.GetComponent<IRoomable>();
    }

    public void Interact()
    {
        OnPassageActivated?.Invoke(this);
        // Debug.Log(_room.GetComponent<IRoomable>());
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Interact();
        }    
    }
}
