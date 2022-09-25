using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoInteractable : Interactable
{
    public GameObject canvasBank;
    public GameObject canvasPlayer;

    public bool isUsing = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (isUsing)
        {        
            canvasBank.SetActive(true);
            canvasPlayer.SetActive(false);
        }
        else
        {          
            canvasBank.SetActive(false);
            canvasPlayer.SetActive(true);
        }
    }

    protected override void Interact()
    {
        if (!isUsing)
        {
            GameManager.instance.staticPlayer = true;
            isUsing = true;
        }
    }

    public void VolverGameplay()
    {
        GameManager.instance.staticPlayer = false;
        isUsing = false;
    }
}
