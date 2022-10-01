using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerManager : MonoBehaviour
{
    public TextMeshProUGUI textDineroEfectivo;
    public TextMeshProUGUI textDineroDebito;
    public TextMeshProUGUI textDineroCredito;

    public TextMeshProUGUI hours;
    public TextMeshProUGUI days;

    public int horas;
    public int dias;

    void Start()
    {
        //z.Raycast
    }

    
    void Update()
    {
        textDineroEfectivo.text = "Dinero: S/" + GameManager.instance.dineroEfectivo.ToString();
        textDineroDebito.text = "Debito: S/" + GameManager.instance.dineroDebito.ToString();
        textDineroCredito.text = "Deuda: S/" + GameManager.instance.dineroCredito.ToString();

        horas = (int)GameManager.instance._hour;
        dias = (int)GameManager.instance._day;


        //_day = days[(int)(day % 7)];
        hours.text = string.Format("{0:00}:00", (horas % 24));
        //_hours.text = (hour % 24).ToString();
        days.text = GameManager.instance.days[(dias % 7)];
    }
}
