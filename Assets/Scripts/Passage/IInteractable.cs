using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    void Interact();

}
