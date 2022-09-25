using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBancos : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasBC;
    public GameObject canvasBD;

    public BancoDebito bancoDebito;
    public BancoCredito bancoCredito;
    
    public void AbrirBancoCredito()
    {
        canvasBC.SetActive(true);
        canvasMenu.SetActive(false);
    }

    public void AbrirBancoDebito()
    {
        canvasBD.SetActive(true);
        canvasMenu.SetActive(false);
    }

    public void RegresarMenu()
    {
        canvasBC.SetActive(false);
        canvasBD.SetActive(false);
        canvasMenu.SetActive(true);

        bancoDebito.LimpiarInputDeposito();
        bancoDebito.LimpiarInputRetiro();
        bancoDebito.message.text = "";

        bancoCredito.LimpiarInputPago();
        bancoCredito.LimpiarInputPrestamo();
        bancoCredito.message.text = "";
    }
}
