using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public List<Cuy> CuyesList;
    
    public int countFoodCuy;
    public int countFoodEspecial;
    public int countFoodPlayer;
    
    public int dinero; //Dinero

    public int sleep;
    public int Hambre;
    public int tempHoras;
    public int _hour;
    public float time;
    public float fill1;
    public float fill2;
    public Color barraColor;
    public Image barHambre;
    public Image barSleep;

    public TextMeshProUGUI[] inventario;

    public GameObject stats;
    public List<TextMeshProUGUI> statsText;
    public Cuy cuy;

    void Start()
    {
        
    }

    

    void Update()
    {
        dinero = GameManager.instance.dineroEfectivo;

        _hour = GameManager.instance._hour;

        inventario[0].text = countFoodCuy.ToString();
        inventario[1].text = countFoodEspecial.ToString();
        inventario[2].text = countFoodPlayer.ToString();

        if (cuy != null)
        {
            MostrarStatsCuy();
        }
        
        if (_hour > tempHoras)
        {
            this.fill1 = Mathf.Clamp01(this.fill1 - 0.1f);
            this.barSleep.fillAmount = this.fill1;
            this.fill2 = Mathf.Clamp01(this.fill2 - 0.2f);
            this.barHambre.fillAmount = this.fill2;
            CheckColor(barSleep);
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

    public void MostrarStatsCuy()
    {
        statsText[0].text = "Vida: " + cuy.health.ToString();
        statsText[1].text = cuy.genero.ToString();
        statsText[2].text = cuy.edad.ToString();
        statsText[3].text = cuy.estado.ToString();

        if (cuy.hambre)
        {
            statsText[4].text = "Tiene Hambre";
        }else{
            statsText[4].text = "No tiene Hambre";
        }

        if (cuy.enCelo)
        {
            statsText[5].text = "En celo";
        }else{
            statsText[5].text = "No está en celo";
        }

        if (cuy.embarazado)
        {
            statsText[6].text = "Está embarazada";
        }else{
            if (cuy.genero == Cuy.Genero.macho)
            {
                statsText[6].text = "---------";
            }else{
                statsText[6].text = "No está embarazada";
            }       
        } 
    }
}
