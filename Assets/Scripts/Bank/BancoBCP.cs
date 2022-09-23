using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BancoBCP : MonoBehaviour
{
    //public int 

    public int tmpDeposito;
    public int tmpRetiro;

    public int dineroPlayer;

    void Start()
    {
        
    }

    
    void Update()
    {
        GameManager.instance.moneyPlayerInBank = dineroPlayer;
    }

    public void Depositar()
    {
        if (GameManager.instance.moneyPlayer >= tmpDeposito)
        {
            GameManager.instance.moneyPlayer -= tmpDeposito;
            dineroPlayer += tmpDeposito;
        }
        tmpDeposito = 0;
    }

    public void Retirar()
    {
        if (dineroPlayer >= tmpRetiro)
        {
            dineroPlayer -= tmpRetiro;
            GameManager.instance.moneyPlayer += tmpRetiro;
        }
        tmpRetiro = 0;
    }

    public void ReadDepositar(string _deposito)
    {
        if (!int.TryParse(_deposito, out tmpDeposito))
        {
            Debug.Log("Error");
        }
    }

    public void ReadRetirar(string _retiro)
    {
        if (!int.TryParse(_retiro, out tmpRetiro))
        {
            Debug.Log("Error");
        }
    }
}
