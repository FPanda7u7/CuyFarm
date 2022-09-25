using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<Cuy> CuyesList;
    
    public  int _money;
    public int Sueño;
    public int Hambre;
    public int tempHoras;
    public int _hour;
    public float time;
    public float fill1;
    public float fill2;
    public Color barraColor;
    public Image barHambre;
    public Image barSueño;

    void Start()
    {
        
    }

    

    void Update()
    {
        _money = GameManager.instance.moneyPlayer;
        _hour = GameManager.instance._hour;
        if (_hour > tempHoras)
        {
            this.fill1 = Mathf.Clamp01(this.fill1 - 0.1f);
            this.barSueño.fillAmount = this.fill1;
            this.fill2 = Mathf.Clamp01(this.fill2 - 0.2f);
            this.barHambre.fillAmount = this.fill2;
            CheckColor(barSueño);
            CheckColor(barHambre);
        }
        tempHoras = _hour;
    }
    public void CheckColor(Image barra)
    {
        if (barra.fillAmount >= 0.7)
        {
            this.barraColor = Color.green;
        }
        if (barra.fillAmount > 0.4 && barra.fillAmount <= 0.6)
        {
            this.barraColor = Color.yellow;
        }
        if (barra.fillAmount <= 0.4)
        {
            this.barraColor = Color.red;
        }
        barra.color = barraColor;
    }
}
