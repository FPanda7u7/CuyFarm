using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyInteractable : Interactable
{
    public Transform pivot;
    private Rigidbody rb;

    private PlayerStats player;
    private Cuy cuy;
    private CuyController cuyController;
    
    private void Awake()
    {   
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        pivot = GameObject.FindGameObjectWithTag("PivotMano").GetComponent<Transform>();
        cuyController = GetComponent<CuyController>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.SetParent(null);
            
            cuyController.playIA();
        }
    }

    protected override void Interact()
    {
        if (cuy.hambre && player.countFoodCuy > 0)
        {
            cuy.hambre = false;
        }
    }

    protected override void InteractSecond()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        
        transform.position = pivot.position;
        transform.SetParent(pivot);

        cuyController.stopIA();
    }
}
