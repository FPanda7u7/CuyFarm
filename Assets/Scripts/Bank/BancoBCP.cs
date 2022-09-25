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

    public TMP_InputField _tmpRetiro;
    public TMP_InputField _tmpDeposito;


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
        dineroPlayer = GameManager.instance.dineroDebito;

        saldoPlayerInBank.text = "$ " + dineroPlayer.ToString();
        saldoPlayer.text = "$ " + GameManager.instance.dineroEfectivo.ToString();
    }

    public void Depositar()
    {
        if (depositoCorrecto)
        {
            if (GameManager.instance.dineroEfectivo >= tmpDeposito)
            {
                if (tmpDeposito != 0)
                {
                    GameManager.instance.dineroEfectivo -= tmpDeposito;
                    GameManager.instance.dineroDebito += tmpDeposito;
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
        LimpiarInputDeposito();
    }

    public void Retirar()
    {
        if (retiroCorrecto)
        {
            if (dineroPlayer >= tmpRetiro)
            {
                if (tmpRetiro != 0)
                {
                    GameManager.instance.dineroDebito -= tmpRetiro;
                    GameManager.instance.dineroEfectivo += tmpRetiro;
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
        LimpiarInputRetiro();
    }

    public void ReadDepositar(string _deposito)
    {
        depositoCorrecto = int.TryParse(_deposito, out tmpDeposito);
    }

    public void ReadRetirar(string _retiro)
    {
        retiroCorrecto = int.TryParse(_retiro, out tmpRetiro);
    }

    public void LimpiarInputDeposito()
    {
        _tmpDeposito.Select();
        _tmpDeposito.text = "";
    }

    public void LimpiarInputRetiro()
    {
        _tmpRetiro.Select();
        _tmpRetiro.text = "";
    }
}
