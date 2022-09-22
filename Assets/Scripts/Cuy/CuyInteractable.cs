using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyInteractable : Interactable
{
    public Transform pivot;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.SetParent(null);
            //parent = false;
        }
    }

    protected override void Interact()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        
        transform.position = pivot.position;
        //parent = true;
        transform.SetParent(pivot);
    }
}
