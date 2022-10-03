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
    public Button boton2;
    public GameObject _tiempo;

    public int horas;
    public int dias;

    private bool tmp_durmiendo;

    [SerializeField] private EdificioInteractable interactuable;

    void Start()
    {
        
    }

    void Update()
    {
        horas = (int)GameManager.instance._hour;
        dias = (int)GameManager.instance._day;

        hours.text = string.Format("{0:00}:00", (horas % 24));
        days.text = GameManager.instance.days[(dias % 7)];

        if (horas == 7 && tmp_durmiendo)
        {
            tmp_durmiendo = false;
            boton.interactable = true;
            player.sueño = true;
            player.hambre = true;
        }
    }

    public void Dormir()
    {
        if (GameManager.instance._hour >= 22)
        {         
            tmp_durmiendo = true;
            _tiempo.SetActive(true);
            boton.interactable = false;
            message.text = "Durmiendo";
            Time.timeScale = 20;
            player.hambre = false;
            player.sueño = false;

        }else{
            message.text = "Solo puedes dormir a partir de las 22:00";
        }
    }
}
