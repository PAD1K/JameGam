using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject _startRoom;

    [SerializeField] private Transform _upPassage;
    [SerializeField] private Transform _downPassage;
    [SerializeField] private Transform _leftPassage;
    [SerializeField] private Transform _rightPassage;

    private IRoomable _currentRoom;

    private void Awake() 
    {
        Passage.OnPassageActivated += ChangeRoom;
        _currentRoom = _startRoom.GetComponent<IRoomable>();    
    }

    private void ChangeRoom(IPassage passage)
    {
        _currentRoom?.Hide();
        _currentRoom = passage.Room;
        ChangePosition(passage.Type);
        _currentRoom?.Reveal();
    }

    private void ChangePosition(string type)
    {
        switch(type)
        {
            case "Up":
                transform.position = _downPassage.position;
                break;
            case "Down":
                transform.position = _upPassage.position;
                break;
            case "Left":
                transform.position = _rightPassage.position;
                break;
            case "Right":
                transform.position = _leftPassage.position;
                break;
        }
    }
}
