using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public PlayerStats player;

    public TextMeshProUGUI days;
    public TextMeshProUGUI hours;
    public TextMeshProUGUI message;

    public Button boton;

    public int horas;
    public int dias;

    [SerializeField] private EdificioInteractable interactuable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horas = (int)GameManager.instance._hour;
        dias = (int)GameManager.instance._day;

        hours.text = string.Format("{0:00}:00", (horas % 24));
        days.text = GameManager.instance.days[(dias % 7)];

        if (horas >= 7)
        {
            boton.interactable = true;
            player.sueño = false;

            if (horas <= 22)
            {
                player.hambre = true;
            }
        }

    }

    public void Dormir()
    {
        if (GameManager.instance._hour >= 22)
        {         
            player.hambre = false;
            player.sueño = true;
            GameManager.instance.staticPlayer = true;
            Time.timeScale = 20;
            boton.interactable = false;
        }else{
            message.text = "Solo puedes dormir a partir de las 22:00";
        }
    }
}
