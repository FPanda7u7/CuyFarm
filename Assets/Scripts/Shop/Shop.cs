using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    public GameObject canvasShop;
    public GameObject canvasPlayer;

    public bool usando = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (usando)
        {
            canvasShop.SetActive(true);
            canvasPlayer.SetActive(false);
        }
        else
        {          
            canvasShop.SetActive(false);
            canvasPlayer.SetActive(true);
        }
    }

    protected override void Interact()
    {
        if (!usando)
        {
            GameManager.instance.staticPlayer = true;
            usando = true;
        }
    }

    public void VolverGameplay()
    {
        GameManager.instance.staticPlayer = false;
        usando = false;
    }
}
