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

    public float tmpHambre;
    public float hambre;
    public float hambreMax = 200;


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
        hambre = hambreMax;
    }

    void Update()
    {
        _hour = GameManager.instance._hour;

        Dormir();

        if (cuy != null)
        {
            MostrarStatsCuy();
        }

        hambre -= Time.deltaTime;
        hambre = Mathf.Clamp(hambre, 0, hambreMax);  
        barHambre.fillAmount = hambre / hambreMax;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventario.comidaPlayer > 0 && inventario.selection == 2)
            {
                hambre += 100;
                inventario.comidaPlayer--;
            }
        }
        
        CheckColor(barHambre);

        if (hambre <= 0)
        {
            transform.position = hospital.position;
            GameManager.instance.dineroCredito += 75;
            hambre = hambreMax;
        }
        Perder();
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

    public void Dormir()
    {
        if (GameManager.instance._hour >= 23)
        {
            GameManager.instance.timeElapsed += 150f;
            this.transform.position = hospital.position;
            GameManager.instance.dineroCredito += 50;
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

    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
