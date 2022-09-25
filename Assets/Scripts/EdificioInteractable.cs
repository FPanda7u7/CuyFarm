using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdificioInteractable : Interactable
{
    public GameObject canvasPlayer;
    public GameObject canvasEdificio;

    private bool isUsing = false;

    void Start()
    {
        
    }

    
    void Update()
    {

    }

    protected override void Interact()
    {
        if (!isUsing)
        {
            canvasEdificio.SetActive(true);
            canvasPlayer.SetActive(false);
            GameManager.instance.staticPlayer = true;
            isUsing = true;
        }
    }

    public void VolverGameplay()
    {
        canvasEdificio.SetActive(false);
        canvasPlayer.SetActive(true);
        GameManager.instance.staticPlayer = false;
        isUsing = false;

        Shop shop = GetComponent<Shop>();
        if (shop != null){
            shop.countFoodCuy = 0;
            shop.countFoodPlayer = 0;
        }

        BancoBCP bancoBCP = GetComponent<BancoBCP>();
        if (bancoBCP != null){
            bancoBCP.LimpiarInputDeposito();
            bancoBCP.LimpiarInputRetiro();
            bancoBCP.message.text = "";
        }
    }
}
