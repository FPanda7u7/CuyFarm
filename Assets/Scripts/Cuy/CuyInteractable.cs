using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        cuy = GetComponent<Cuy>();
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
            
            player.stats.gameObject.SetActive(false);
            cuyController.playIA();
        }
    }

    protected override void Interact()
    {
        if (cuy.hambre)
        {
            if (player.inventario.comidaCuyEspecial > 0 && player.inventario.selection == 1)
            {
                cuy.health++;
                player.inventario.comidaCuyEspecial--;
                cuy.hambre = false;
                return;
            }

            if (player.inventario.comidaCuy > 0 && player.inventario.selection == 0)
            {
                player.inventario.comidaCuy--;
                cuy.hambre = false;
                return;
            }
        }
    }

    protected override void InteractSecond()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        
        transform.position = pivot.position;
        transform.SetParent(pivot);

        cuyController.stopIA();

        player.stats.gameObject.SetActive(true);
        player.cuy = this.cuy;
    }
}
