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

    void Start()
    {
        
    }

    
    void Update()
    {
        textMoneyPlayer.text = "Dinero: $" + moneyPlayer.ToString();
        textMoneyPlayerInBank.text = "Banco: $" + moneyPlayerInBank.ToString();
    }
}
