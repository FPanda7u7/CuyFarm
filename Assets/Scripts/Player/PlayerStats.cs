using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public PlayerInventory inventario;
    
    public List<Cuy> CuyesList;

    public bool tengoBoleto;

    public bool sueño;
    public bool hambre;
    public bool _sueño;
    public bool _hambre;
    
    public float tmpHambre;
    public float hambreVal;
    public float hambreMax;

    public int tempHoras;
    public float _hour;
    public float time;
    public float fill;

    public Color barraColor;
    public Image barHambre;

    public Transform hospital;

    public GameObject stats;
    public List<TextMeshProUGUI> statsText;
    public Cuy cuy;

    public GameObject canvasPerder;
    public GameObject Durmiendo;
    
    public TextMeshProUGUI days;
    public TextMeshProUGUI hours;
    public int horas;
    public int dias;

    public static PlayerStats instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        inventario = GetComponent<PlayerInventory>();    
    }

    private void Start()
    {
        hambreVal = hambreMax;
        sueño = true;
        hambre = true;
    }

    void Update()
    {
        _hour = GameManager.instance._hour;

        if (_sueño)
        {
            gameObject.transform.position = hospital.position;
            gameObject.transform.rotation = hospital.rotation;
            _sueño = false;
        }

        if (_hambre)
        {
            gameObject.transform.position = hospital.position;
            gameObject.transform.rotation = hospital.rotation;
            _hambre = false;
        }

        horas = (int)GameManager.instance._hour;
        dias = (int)GameManager.instance._day;

        hours.text = string.Format("{0:00}:00", (horas % 24));
        days.text = GameManager.instance.days[(dias % 7)];

        Dormir();
        Hambre();
        Perder();

        if (cuy != null)
        {
            MostrarStatsCuy();
        }               
    }

    public void CheckColor(Image barra)
    {
        if (barra.fillAmount >= 0.7)
        {
            this.barraColor = Color.green;
        }
        if (barra.fillAmount > 0.2 && barra.fillAmount <= 0.6)
        {
            this.barraColor = Color.yellow;
        }
        if (barra.fillAmount <= 0.2)
        {
            this.barraColor = Color.red;
        }
        barra.color = barraColor;
    }

    public void Hambre()
    {
        if (hambre)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inventario.comidaPlayer > 0 && inventario.selection == 2)
                {
                    hambreVal += 100;
                    inventario.comidaPlayer--;
                }
            }

            hambreVal -= Time.deltaTime;
            hambreVal = Mathf.Clamp(hambreVal, 0, hambreMax);
            barHambre.fillAmount = hambreVal / hambreMax;

            if (hambreVal <= 0)
            {
                NotificacionManager.instance.CrearNotificacion("Procura comer, se te cobro S/75");
                GameManager.instance.dineroCredito += 75;
                hambreVal = hambreMax;
                _hambre = true;
            }
            CheckColor(barHambre);
        }      
    }
    
    public void Dormir()
    {
        if (GameManager.instance._hour >= 23 && sueño)
        {
            NotificacionManager.instance.CrearNotificacion("Procura dormir, se te cobro S/50");
            GameManager.instance.dineroCredito += 50;
            Durmiendo.SetActive(true);
            _sueño = true;
            sueño = false;
        }
    }

    public void Perder()
    {
        if (GameManager.instance._day == 15 || GameManager.instance._day == 28)
        {
            if (CuyesList.Count == 0 && GameManager.instance.dineroCredito > 0)
            {
                canvasPerder.gameObject.SetActive(true);
                GameManager.instance.staticPlayer = true;
            }else{
                for (int i = 0; i < CuyesList.Count; i++)
                {
                    GameObject _tmpCuy = CuyesList[i].gameObject;
                    CuyesList.Remove(CuyesList[i]);
                    Destroy(_tmpCuy);
                }
            }
        }
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

    public void VolverGameplay()
    {
        if (GameManager.instance._hour >= 7 && GameManager.instance._hour < 23)
        {
            Durmiendo.SetActive(false);
            GameManager.instance.staticPlayer = false;
        }
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
