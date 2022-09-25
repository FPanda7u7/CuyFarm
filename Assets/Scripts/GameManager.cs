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

    public int moneyPlayer;
    public int moneyPlayerInBank;

    public int Sueño;
    public int Hambre;
    public float tempHoras;

    public TMP_Text textMoneyPlayer;
    public TMP_Text textMoneyPlayerInBank;

    public double timeElapsed;

    public float hour;
    public float day;
    public float week;
    public float month;

    public int _hour;
    public int _day;
    public string _week;
    public string _month;

    public TMP_Text _hours;
    public TMP_Text _days;

    public float time;
    public float fill1;
    public float fill2;
    public Color barraColor;

    public Image barHambre;
    public Image barSueño;

    public string[] days = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"};

    void Start()
    {
        Time.timeScale = 20;
    }

    
    void Update()
    {
        CountTime();
        
        if (staticPlayer)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;

        textMoneyPlayer.text = "Dinero: $" + moneyPlayer.ToString();
        textMoneyPlayerInBank.text = "Banco: $" + moneyPlayerInBank.ToString();

        if (hour > tempHoras)
        {
            this.fill1 = Mathf.Clamp01(this.fill1 - 0.1f);
            this.barSueño.fillAmount = this.fill1;
            this.fill2 = Mathf.Clamp01(this.fill2 - 0.2f);
            this.barHambre.fillAmount = this.fill2;
            tempHoras = hour;
            CheckColor(barSueño);
            CheckColor(barHambre);
        }
    }

    void CountTime()
    {
        timeElapsed += Time.deltaTime;
        
        hour = (int)(timeElapsed/ 25f);
        day = (int)(hour / 24f);
        week = (int)(day / 7f);
        month = (int)(week / 4f);

        _hour = (int)(hour % 24);
        _day = (int)(day % 7) + 1;
        //_week = ((week % 4) + 1).ToString();
        //_month = ((month) + 1).ToString();

        //_day = days[(int)(day % 7)];
        _hours.text = string.Format("{0:00}:00", (hour % 24));
        //_hours.text = (hour % 24).ToString();
        _days.text = days[(int)(day % 7)];
    }
    public void CheckColor(Image barra)
    {
        if(barra.fillAmount >= 0.7)
        {
            this.barraColor = Color.green;
        }
        if(barra.fillAmount > 0.4 && barra.fillAmount <= 0.6)
        {
            this.barraColor = Color.yellow;
        }
        if(barra.fillAmount <= 0.4)
        {
            this.barraColor = Color.red;
        }
        barra.color = barraColor;
    }
}
