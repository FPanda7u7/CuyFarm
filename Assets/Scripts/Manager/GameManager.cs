using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;    
    }
    #endregion

    public bool staticPlayer;

    public int dineroEfectivo;
    public int dineroDebito;
    public int dineroCredito;

    public double timeElapsed;

    public float hour;
    public float day;
    public float week;
    public float month;

    public float _hour;
    public float _day;
    public float _week;
    public float _month;

    public string[] days = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"};

    void Start()
    {
        //Time.timeScale = 50;

        timeElapsed += 150;
    }

    
    void Update()
    {
        CountTime();

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 50;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1;
        }
        
        if (staticPlayer)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    void CountTime()
    {
        timeElapsed += Time.deltaTime;
        
        hour = (float)(timeElapsed/ 20f);
        day = (hour / 24f);
        week = (day / 7f);
        month = (week / 4f);

        _hour = (hour % 24);
        _day = (day % 7);
    }
}
