using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Object foodCuy;
    public Object foodPlayer;

    public int countFoodCuy;
    public int countFoodPlayer;
    public int countTotal;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AgregarAlCarrito(string comida)
    {  
        if (comida == "Comida Cuy")
        {
            countFoodCuy += Mathf.Clamp(0, 100, countFoodCuy);
        }

        if (comida == "Comida Player")
        {
            countTotal += foodPlayer.cost;
        }
    }

    public void QuitarAlCarrito(string comida)
    {
        if (comida == "Comida Cuy")
        {
            countTotal -= foodCuy.cost;
        }
        
        if (comida == "Comida Player")
        {
            countTotal -= foodPlayer.cost;
        }
    }

    public void BuyFoodPlayer()
    {

    }
}
