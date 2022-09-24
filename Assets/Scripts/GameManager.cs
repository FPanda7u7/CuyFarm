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

    public float time;

    public float hour;
    public float day;
    public float month;

    void Start()
    {
        Time.timeScale = 5;
    }

    
    void Update()
    {
        CountTime();
        
        textMoneyPlayer.text = "Dinero: $" + moneyPlayer.ToString();
        textMoneyPlayerInBank.text = "Banco: $" + moneyPlayerInBank.ToString();
    }

    void CountTime()
    {
        time += Time.deltaTime;
        
        if (time >= 40)
        {
            hour++;
            if (hour >= 24)
            {
                hour = 0;
                day++;

                if (day >= 30)
                {
                    day = 0;
                    month++;
                }
            }

            time = 0;
        }
    }
}
