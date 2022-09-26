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

    public float interes;

    public int precioVentaCuy;
    public int countCuyMacho;
    public int countCuyHembra;
    public int countTotal;

    public TMP_Text textTotal;
    public TMP_Text textCuyMacho;
    public TMP_Text textCuyHembra;

    public TMP_Text dineroPlayer;
    public TMP_Text dineroDebito;
    public TMP_Text dineroCredito;
    public TMP_Text dineroCreditoAumento;

    void Start()
    {
        
    }

    
    void Update()
    {
        countTotal = (costoCuy * countCuyMacho) + (costoCuy * countCuyHembra);

        textTotal.text = "Total: $" + countTotal.ToString();
        textCuyMacho.text = countCuyMacho.ToString();
        textCuyHembra.text = countCuyHembra.ToString();

        dineroPlayer.text = "$" + GameManager.instance.dineroEfectivo.ToString();
        dineroDebito.text = "$" + GameManager.instance.dineroDebito.ToString();
        dineroCredito.text = "$" + GameManager.instance.dineroCredito.ToString();
        dineroCreditoAumento.text = "$" + (((int)(countTotal * interes)) - countTotal).ToString();

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
            cuyBebe.GetComponent<Cuy>().genero = Cuy.Genero.macho;
        }
        for (int i = 0; i < countCuyHembra; i++)
        {
            GameObject _cuy = Instantiate(gameObjectCuy, cerca.position, cerca.rotation);
            Cuy cuyBebe = _cuy.GetComponent<Cuy>();
            cuyBebe.GetComponent<Cuy>().genero = Cuy.Genero.hembra;
        }
        countTotal = 0;
        countCuyMacho = 0;
        countCuyHembra = 0;
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

    public void VenderCuys()
    {
        if (player.CuyesList.Count > 0)
        {
            int rnd = Random.Range(0, player.CuyesList.Count);

            if (player.CuyesList[rnd].edad == Cuy.Edad.bebe)
            {
                Debug.Log("Cuy bebe no a la venta");
                return;
            }else{
                if (player.CuyesList[rnd].embarazado)
                {
                    GameManager.instance.dineroEfectivo += precioVentaCuy * 2;
                }else{
                    GameManager.instance.dineroEfectivo += precioVentaCuy;
                }
            }
            GameObject _tmpCuy = player.CuyesList[rnd].gameObject;
            player.CuyesList.Remove(player.CuyesList[rnd]);
            Destroy(_tmpCuy);
        }
    }
}
