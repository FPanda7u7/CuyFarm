using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BancoCredito : MonoBehaviour
{
    public TMP_Text deudaTxt;
    public TMP_Text saldoPlayer;
    public TMP_Text saldoDebito;
    public TMP_Text prestamoTotalTxt;
    public TMP_Text message;

    public TMP_InputField _pagoSolicitado;
    public TMP_InputField _prestamoSolicitado;

    public float interes;
    public int prestamoTotal;
    public int prestamoSolicitado;
    public bool hayPrestamo;

    public bool hayPago;
    public int pagoSolicitado;

    void Start()
    {
        interes = 1.5f;
    }

    void Update()
    {
        deudaTxt.text = "$ " + GameManager.instance.dineroCredito.ToString();
        saldoPlayer.text = "$ " + GameManager.instance.dineroEfectivo.ToString();
        saldoDebito.text = "$ " + GameManager.instance.dineroDebito.ToString();

        HallarPrestamoTotal();

    }

    void HallarPrestamoTotal()
    {
        if (hayPrestamo)
        {
            prestamoTotal = (int)(prestamoSolicitado * interes);

            if (prestamoTotal > 0)
            {
                prestamoTotalTxt.text = "$ " + prestamoTotal.ToString();
            }else{
                prestamoTotalTxt.text = "$ 0";
            }    
        }
        else
        {
            prestamoTotalTxt.text = "$ 0";
        }
    }

    public void PagarPrestamo()
    {
        if (pagoSolicitado <= 0)
        {
            message.text = "Ingrese un monto diferente";
        }

        if (GameManager.instance.dineroCredito == 0)
        {
            message.text = "No tienes deudas pendientes";
            LimpiarInputPago();
            return;
        }

        if (hayPago)
        {
            if(GameManager.instance.dineroDebito >= GameManager.instance.dineroCredito)
            {
                if(pagoSolicitado <= GameManager.instance.dineroCredito)
                {
                    GameManager.instance.dineroDebito -= pagoSolicitado;
                    GameManager.instance.dineroCredito -= pagoSolicitado;
                    message.text = "Pago realizado con exito";
                }
                else
                {
                    message.text = "Tienes que pagar una menor cantidad";
                }
            }
            else
            {
                message.text = "Fondos insuficientes";
            }
            
        }
        else
        {
            message.text = "Dígitos incorrectos";
        }

        LimpiarInputPago();
    }

    public void PedirPrestamo()
    {
        if (hayPrestamo)
        {
            if (prestamoSolicitado <= 0)
            {
                message.text = "Ingrese un monto diferente";
            }else{
                GameManager.instance.dineroDebito += prestamoSolicitado;
                GameManager.instance.dineroCredito += prestamoTotal;
                prestamoSolicitado = 0;
                message.text = "Préstamo realizado con éxito";
            }  
        }else{
            message.text = "Dígitos incorrectos";
        }

        LimpiarInputPrestamo();
    }

    public void ReadPrestamo(string _value)
    {
        hayPrestamo = int.TryParse(_value, out prestamoSolicitado);

        //prestamoSolicitado = Mathf.Clamp(prestamoSolicitado, 0, 10000);
    }

    public void ReadPago(string _value)
    {
        hayPago = int.TryParse(_value, out pagoSolicitado);
    }

    public void LimpiarInputPago()
    {
        _pagoSolicitado.Select();
        _pagoSolicitado.text = "";
    }

    public void LimpiarInputPrestamo()
    {
        _prestamoSolicitado.Select();
        _prestamoSolicitado.text = "";
    }
}
