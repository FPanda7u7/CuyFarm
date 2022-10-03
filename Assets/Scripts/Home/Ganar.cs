using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    public TextMeshProUGUI message1;
    public TextMeshProUGUI message2;

    public int precioBoleto;

    public GameObject canvasGanar;

    public TextMeshProUGUI dinero;
    public TextMeshProUGUI _precioBoleto;

    public GameObject compraSFX;

    private void Update()
    {
        dinero.text = GameManager.instance.dineroDebito.ToString();
        _precioBoleto.text = "S/" + precioBoleto.ToString();
    }

    public void ComprarBoleto()
    {
        if (precioBoleto <= GameManager.instance.dineroDebito)
        {
            PlayerStats.instance.tengoBoleto = true;
            GameManager.instance.dineroDebito -= precioBoleto;
            Instantiate(compraSFX);
            message1.text = "Compra Realizada"; 
        }else{
            message1.text = "Dinero insuficiente"; 
        }
    }

    public void TomarAvion()
    {
        if (PlayerStats.instance.tengoBoleto)
        {
            
            if (GameManager.instance.dineroCredito <= 0)
            {
                canvasGanar.SetActive(true);
            }
            else
            {
                message2.text = "Tienes deudas pendientes";
            }

        }
        else
        {
            message2.text = "No tienes el boleto";
        }
        
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
