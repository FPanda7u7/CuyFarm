using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public PlayerStats player;

    public GameObject foodCuy;
    public GameObject foodCuyEspecial;
    public GameObject foodPlayer;

    private Object _foodCuy;
    private Object _foodCuyEspecial;
    private Object _foodPlayer;

    public int countFoodCuy;
    public int countFoodCuyEspecial;
    public int countFoodPlayer;
    public int countTotal;

    public float interes;

    public TMP_Text textTotal;
    public TMP_Text textFoodCuy;
    public TMP_Text textFoodCuyEspecial;
    public TMP_Text textFoodPlayer;

    public TMP_Text dineroPlayer;
    public TMP_Text dineroDebito;
    public TMP_Text dineroCredito;
    public TMP_Text dineroCreditoAumento;

    void Start()
    {
        _foodCuy = foodCuy.GetComponent<Object>();
        _foodCuyEspecial = foodCuyEspecial.GetComponent<Object>();
        _foodPlayer = foodPlayer.GetComponent<Object>();
    }

    
    void Update()
    {
        countTotal = (_foodCuy.cost * countFoodCuy) + (_foodPlayer.cost * countFoodPlayer) + (_foodCuyEspecial.cost * countFoodCuyEspecial);

        textTotal.text = "Total: $" + countTotal.ToString();
        textFoodCuy.text = countFoodCuy.ToString();
        textFoodCuyEspecial.text = countFoodCuyEspecial.ToString();
        textFoodPlayer.text = countFoodPlayer.ToString();

        dineroPlayer.text = "$" + GameManager.instance.dineroEfectivo.ToString();
        dineroDebito.text = "$" + GameManager.instance.dineroDebito.ToString();
        dineroCredito.text = "$" + GameManager.instance.dineroCredito.ToString();
        dineroCreditoAumento.text = "$" + (((int)(countTotal * interes)) - countTotal).ToString();
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

    public void AgregarInventarioPlayer()
    {
        for (int i = 0; i < countFoodCuy; i++)
        {
            player.countFoodCuy++;
        }
        for (int i = 0; i < countFoodCuyEspecial; i++)
        {
            player.countFoodEspecial++;
        }
        for (int i = 0; i < countFoodPlayer; i++)
        {
            player.countFoodPlayer++;
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
        }      
    }

    public void PagarDebito()
    {
        if (GameManager.instance.dineroDebito >= countTotal)
        {
            GameManager.instance.dineroDebito -= countTotal;
            AgregarInventarioPlayer();
        }       
    }

    public void PagarCredito()
    {
        GameManager.instance.dineroCredito += (int)(countTotal * interes);
        AgregarInventarioPlayer();
    }
}
