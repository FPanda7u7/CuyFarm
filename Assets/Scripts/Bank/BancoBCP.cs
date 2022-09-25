using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BancoBCP : MonoBehaviour
{
    public TMP_Text saldoPlayer;
    public TMP_Text saldoPlayerInBank;
    public TMP_Text message;

    public int tmpDeposito;
    public int tmpRetiro;

    public int dineroPlayer;

    private bool depositoCorrecto;
    private bool retiroCorrecto;

    void Start()
    {
        
    }

    
    void Update()
    {
        GameManager.instance.moneyPlayerInBank = dineroPlayer;

        saldoPlayerInBank.text = "$ " + dineroPlayer.ToString();
        saldoPlayer.text = "$ " + GameManager.instance.moneyPlayer.ToString();
    }

    public void Depositar()
    {
        if (depositoCorrecto)
        {
            if (GameManager.instance.moneyPlayer >= tmpDeposito)
            {
                if (tmpDeposito != 0)
                {
                    GameManager.instance.moneyPlayer -= tmpDeposito;
                    dineroPlayer += tmpDeposito;
                    message.text = "Deposito realizado con éxito";
                }else{
                    message.text = "Ingrese un monto diferente de 0";
                }   
            }else{
                message.text = "Dinero insuficiente";
            }
        }else{
            message.text = "Dígitos incorrectos";
        }    
    }

    public void Retirar()
    {
        if (retiroCorrecto)
        {
            if (dineroPlayer >= tmpRetiro)
            {
                if (tmpRetiro != 0)
                {
                    dineroPlayer -= tmpRetiro;
                    GameManager.instance.moneyPlayer += tmpRetiro;
                    message.text = "Retiro realizado con éxito";
                }else{
                    message.text = "Ingrese un monto diferente de 0";
                }              
            }else{
                message.text = "Saldo insuficiente";
            }
        }else{
            message.text = "Dígitos incorrectos";
        } 
    }

    public void ReadDepositar(string _deposito)
    {
        depositoCorrecto = int.TryParse(_deposito, out tmpDeposito);
    }

    public void ReadRetirar(string _retiro)
    {
        retiroCorrecto = int.TryParse(_retiro, out tmpRetiro);
    }
}
