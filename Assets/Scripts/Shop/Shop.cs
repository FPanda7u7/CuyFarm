using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public PlayerInventory player;

    public GameObject foodCuy;
    public GameObject foodCuyEspecial;
    public GameObject foodPlayer;

    private Item _foodCuy;
    private Item _foodCuyEspecial;
    private Item _foodPlayer;

    public int countFoodCuy;
    public int countFoodCuyEspecial;
    public int countFoodPlayer;
    public int countTotal;

    public float interes;

    public TextMeshProUGUI textFoodCuy;
    public TextMeshProUGUI textFoodCuyEspecial;
    public TextMeshProUGUI textFoodPlayer;

    public TextMeshProUGUI textTotal;
    public TextMeshProUGUI textMessage;

    public TextMeshProUGUI dineroPlayer;
    public TextMeshProUGUI dineroDebito;
    public TextMeshProUGUI dineroCredito;
    public TextMeshProUGUI dineroCreditoAumento;

    void Start()
    {
        _foodCuy = foodCuy.GetComponent<Item>();
        _foodCuyEspecial = foodCuyEspecial.GetComponent<Item>();
        _foodPlayer = foodPlayer.GetComponent<Item>();
    }

    
    void Update()
    {
        countTotal = (_foodCuy.data.cost * countFoodCuy) + (_foodPlayer.data.cost * countFoodPlayer) + (_foodCuyEspecial.data.cost * countFoodCuyEspecial);

        textTotal.text = "S/" + countTotal.ToString();
        textFoodCuy.text = countFoodCuy.ToString();
        textFoodCuyEspecial.text = countFoodCuyEspecial.ToString();
        textFoodPlayer.text = countFoodPlayer.ToString();

        dineroPlayer.text = "S/" + GameManager.instance.dineroEfectivo.ToString();
        dineroDebito.text = "S/" + GameManager.instance.dineroDebito.ToString();
        dineroCredito.text = "S/" + GameManager.instance.dineroCredito.ToString();
        dineroCreditoAumento.text = " Interés: S/" + (((int)(countTotal * interes)) - countTotal).ToString();
    }

    public void AgregarAlCarrito(string comida)
    {  
        if (comida == "Comida Cuy")
        {
            countFoodCuy = Mathf.Clamp(countFoodCuy + 1, 0, 100);
        }

        if (comida == "Comida Cuy Especial")
        {
            countFoodCuyEspecial = Mathf.Clamp(countFoodCuyEspecial + 1, 0, 100);
        }

        if (comida == "Comida Player")
        {
            countFoodPlayer = Mathf.Clamp(countFoodPlayer + 1, 0, 100);
        }
    }

    public void QuitarAlCarrito(string comida)
    {
        if (comida == "Comida Cuy")
        {
            countFoodCuy = Mathf.Clamp(countFoodCuy - 1, 0, 100);
        }

        if (comida == "Comida Cuy Especial")
        {
            countFoodCuyEspecial = Mathf.Clamp(countFoodCuyEspecial - 1, 0, 100);
        }
        
        if (comida == "Comida Player")
        {
            countFoodPlayer = Mathf.Clamp(countFoodPlayer - 1, 0, 100);
        }
    }

    /*public void AgregarInventarioPlayer()
    {
        for (int i = 0; i < countFoodCuy; i++)
        {
            player.comidaCuy++;
        }
        for (int i = 0; i < countFoodCuyEspecial; i++)
        {
            player.comidaCuyEspecial++;
        }
        for (int i = 0; i < countFoodPlayer; i++)
        {
            player.comidaPlayer++;
        }
        countTotal = 0;
        countFoodCuy = 0;
        countFoodCuyEspecial = 0;
        countFoodPlayer = 0;
        textMessage.text = "Compra realizada";
    }*/

    public void AgregarInventarioPlayer()
    {
        player.comidaCuy += countFoodCuy;
        player.comidaCuyEspecial += countFoodCuyEspecial;
        player.comidaPlayer += countFoodPlayer;
        
        if (countTotal != 0)
        {
            textMessage.text = "Compra realizada";
        }else{
            textMessage.text = "Carrito vacío";
        }

        countTotal = 0;
        countFoodCuy = 0;
        countFoodCuyEspecial = 0;
        countFoodPlayer = 0;
        
    }

    public void PagarEfectivo()
    {
        if (GameManager.instance.dineroEfectivo >= countTotal)
        {
            GameManager.instance.dineroEfectivo -= countTotal;
            AgregarInventarioPlayer();
        }else{
            textMessage.text = "Compra fallida";
        }   
    }

    public void PagarDebito()
    {
        if (GameManager.instance.dineroDebito >= countTotal)
        {
            GameManager.instance.dineroDebito -= countTotal;
            AgregarInventarioPlayer();
        }else{
            textMessage.text = "Compra fallida";
        }       
    }

    public void PagarCredito()
    {
        GameManager.instance.dineroCredito += (int)(countTotal * interes);
        AgregarInventarioPlayer();
    }
}
