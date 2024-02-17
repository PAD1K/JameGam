using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour, IInteractable
{
    public delegate void InterctHandler();
    public static event InterctHandler OnInteract;
    public void Interact()
    {
        // TODO: анимация
        OnInteract?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
        {
            return;
        }

        Interact();
    }
}