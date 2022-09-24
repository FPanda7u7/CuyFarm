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

    public int moneyPlayer;
    public int moneyPlayerInBank;

    public TMP_Text textMoneyPlayer;
    public TMP_Text textMoneyPlayerInBank;

    public double timeElapsed;

    public float hour;
    public float day;
    public float week;
    public float month;

    public string _hour;
    public string _day;
    public string _week;
    public string _month;

    void Start()
    {
        //Time.timeScale = 5;
    }

    
    void Update()
    {
        CountTime();
        
        textMoneyPlayer.text = "Dinero: $" + moneyPlayer.ToString();
        textMoneyPlayerInBank.text = "Banco: $" + moneyPlayerInBank.ToString();
    }

    void CountTime()
    {
        timeElapsed += Time.deltaTime;
        
        hour = (int)(timeElapsed/ 25f);
        day = (int)(hour / 24f);
        week = (int)(day / 7f);
        month = (int)(week / 4f);

        _hour = (hour % 24).ToString();
        _day = ((day % 7) + 1).ToString();
        _week = ((week % 4) + 1).ToString();
        _month = ((month) + 1).ToString();

    }
}
