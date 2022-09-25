using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string prompMessage;

    public void BaseInteract()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {

    }

    public void BaseInteractSecond()
    {
        InteractSecond();
    }
    
    protected virtual void InteractSecond()
    {

    }
}
