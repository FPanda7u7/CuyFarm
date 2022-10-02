using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCuy : MonoBehaviour
{
    public PlayerStats player;

    public GameObject gameObjectCuy;

    public int costoCuy;

    public Transform cerca;

    public int precioVentaCuy;
    public int countCuyMacho;
    public int countCuyHembra;
    public int countTotal;

    public TextMeshProUGUI textTotalCuys;
    public TextMeshProUGUI textMessageVenta;

    public TextMeshProUGUI textTotal;
    public TextMeshProUGUI textCuyMacho;
    public TextMeshProUGUI textCuyHembra;
    public TextMeshProUGUI textMessageCompra;

    public TextMeshProUGUI dineroPlayer;

    void Start()
    {
        
    }

    
    void Update()
    {
        countTotal = (costoCuy * countCuyMacho) + (costoCuy * countCuyHembra);

        textTotal.text = "Total: $" + countTotal.ToString();
        textTotalCuys.text = player.CuyesList.Count.ToString();
        textCuyMacho.text = countCuyMacho.ToString();
        textCuyHembra.text = countCuyHembra.ToString();

        dineroPlayer.text = "$" + GameManager.instance.dineroEfectivo.ToString();        
    }

    public void AgregarAlCarrito(string cuyGenero)
    {  
        if (cuyGenero == "Cuy Macho")
        {
            countCuyMacho = Mathf.Clamp(countCuyMacho + 1, 0, 100);
        }

        if (cuyGenero == "Cuy Hembra")
        {
            countCuyHembra = Mathf.Clamp(countCuyHembra + 1, 0, 100);
        }
    }

    public void QuitarAlCarrito(string cuyGenero)
    {
        if (cuyGenero == "Cuy Macho")
        {
            countCuyMacho = Mathf.Clamp(countCuyMacho - 1, 0, 100);
        }
        
        if (cuyGenero == "Cuy Hembra")
        {
            countCuyHembra = Mathf.Clamp(countCuyHembra - 1, 0, 100);
        }
    }

    public void AgregarInventarioPlayer()
    {
        for (int i = 0; i < countCuyMacho; i++)
        {
            GameObject _cuy = Instantiate(gameObjectCuy, cerca.position, cerca.rotation);
            Cuy cuyBebe = _cuy.GetComponent<Cuy>();
            cuyBebe.edad = Cuy.Edad.bebe;
            cuyBebe.genero = Cuy.Genero.macho;
            cuyBebe.embarazado = false;
        }
        for (int i = 0; i < countCuyHembra; i++)
        {
            GameObject _cuy = Instantiate(gameObjectCuy, cerca.position, cerca.rotation);
            Cuy cuyBebe = _cuy.GetComponent<Cuy>();
            cuyBebe.edad = Cuy.Edad.bebe;
            cuyBebe.genero = Cuy.Genero.hembra;
            cuyBebe.embarazado = false;
        }

        textMessageCompra.text = "Compra realizada";
        countTotal = 0;
        countCuyMacho = 0;
        countCuyHembra = 0;
    }

    public void PagarEfectivo()
    {
        if (countTotal > 0)
        {
            if (GameManager.instance.dineroEfectivo >= countTotal)
            {
                GameManager.instance.dineroEfectivo -= countTotal;
                AgregarInventarioPlayer();
            }else{
                textMessageCompra.text = "Dinero insuficiente";
            }
        }else{
            textMessageCompra.text = "Carrito vacío";
        }        
    }

    public void VenderCuys()
    {
        if (player.CuyesList.Count > 0)
        {
            int rnd = Random.Range(0, player.CuyesList.Count);

            if (player.CuyesList[rnd].edad == Cuy.Edad.bebe)
            {
                textMessageVenta.text = "Cuy bebé no a la venta";
                Debug.Log("Cuy bebe no a la venta");
                return;
            }else{
                if (player.CuyesList[rnd].embarazado)
                {
                    textMessageVenta.text = "Se vendió cuy embarazada";
                    GameManager.instance.dineroEfectivo += precioVentaCuy * 2;
                }else{
                    textMessageVenta.text = "Se vendió cuy normal";
                    GameManager.instance.dineroEfectivo += precioVentaCuy;
                }
            }
            GameObject _tmpCuy = player.CuyesList[rnd].gameObject;
            player.CuyesList.Remove(player.CuyesList[rnd]);
            Destroy(_tmpCuy);
        }else{
            textMessageVenta.text = "No tienes cuys";
        }
    }
}
