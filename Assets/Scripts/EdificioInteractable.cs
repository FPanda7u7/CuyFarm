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

        Ganar ganar = GetComponent<Ganar>();
        if (ganar != null){
            ganar.message1.text = "";
            ganar.message2.text = "";
        }

        Shop shop = GetComponent<Shop>();
        if (shop != null){
            shop.countFoodCuy = 0;
            shop.countFoodPlayer = 0;
            shop.textMessage.text = "Bienvenido";
        }

        ShopCuy shopCuy = GetComponent<ShopCuy>();
        if (shopCuy != null){
            shopCuy.countCuyMacho = 0;
            shopCuy.countCuyHembra = 0;
            shopCuy.textMessageVenta.text = "";
            shopCuy.textMessageCompra.text = "Bienvenido";
        }

        Home home = GetComponent<Home>();
        if (home != null){
            home.message.text = "";
        }       
    }
}
