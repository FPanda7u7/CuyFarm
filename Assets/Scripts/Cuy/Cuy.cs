using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cuy : MonoBehaviour
{
    public enum Genero { macho, hembra};
    public enum Edad { bebe, adulto};
    public enum Estado { sano, enfermo};

    public Genero genero;
    public Edad edad;
    public Estado estado;

    //Tiempos
    private bool creciendo;
    private float tiempoEdad;
    private float hour;
    private float day;      // horas contadas
    private float _day;     // días contados
    private float _hour;    // 0 - 24 horas

    public int health = 3;
    
    [Header("Alimentación")]
    public bool hambre;
    public float tiempoComer;
    private float tmp_tiempoComer;

    [Header("Embarazo")]
    public bool embarazado;
    public float tiempoEmbarazo;

    [Header("Celo")]
    public bool enCelo;
    private bool tmp_enCelo;
    public float tiempoEnCelo;

    public GameObject gameObjectCuy;
    private PlayerStats player;
    private CuyController cuyController;

    public MeshRenderer materialCuy;
    public Material materialMacho;
    public Material materialHembra;   
    public GameObject alert;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); 
        cuyController = GetComponent<CuyController>();   
    }

    void Start()
    {
        AgregarMaterial();
        player.CuyesList.Add(this);
    }

    
    void Update()
    {
        hour = GameManager.instance.hour; // horas contadas
        day = GameManager.instance.day; // días contados
        _hour = (int)GameManager.instance._hour; // 0 - 24 horas
    
        Salud();
        Crecimiento();
        Hambre();
        Aparearse();
        Embarazo();      
    }

    public void Salud()
    {
        health = Mathf.Clamp(health, 0, 3);
        if (health == 0)
        {
            player.CuyesList.Remove(this);
            Destroy(this.gameObject);
        }
    }

    public void Hambre()
    {     
        if (hambre)
        {
            alert.SetActive(true);
            tiempoComer += Time.deltaTime;

            if (tiempoComer >= 50)
            {
                health--;
                hambre = false;
                tiempoComer = 0;
            }
        }else{
            alert.SetActive(false);
            if (_hour == 8 || _hour == 13 || _hour == 18)
            {
                if (tmp_tiempoComer != _hour)
                {
                    hambre = true;
                    tmp_tiempoComer = _hour;
                }
            }
            tiempoComer = 0;
        }
    }

    public void Aparearse()
    {
        if (!enCelo)
        {
            if (!tmp_enCelo)
            {
                tiempoEnCelo = day;
                tmp_enCelo = true;
            }else{
                if (day >= tiempoEnCelo + 3)
                {
                    if (estado == Estado.sano && edad == Edad.adulto && !embarazado)
                    {
                        enCelo = true;
                        tmp_enCelo = false;
                        Debug.Log("en celo");
                    }
                }
            }              
        }else{
            BuscarPareja();
        }
    }

    public void Embarazo()
    {
        if (embarazado)
        {
            if (day >= tiempoEmbarazo + 6)
            {
                int cantidaHijos = Random.Range(3, 6);
                for (int i = 0; i < cantidaHijos; i++)
                {
                    GameObject cuyBebe = Instantiate(gameObjectCuy, this.transform);
                    cuyBebe.transform.SetParent(null);
                    cuyBebe.GetComponent<Cuy>().genero = (Genero)Random.Range(0, 2);
                }
                embarazado = false;
                tiempoEmbarazo = 0;
            }
        }
    }

    public void BuscarPareja()
    {
        for (int i = 0; i < player.CuyesList.Count; i++)
        {
            Cuy cuy = player.CuyesList[i].GetComponent<Cuy>();
            if (this.gameObject.GetInstanceID() != cuy.GetInstanceID() &&
                cuy.estado == Estado.sano && cuy.edad == Edad.adulto && !cuy.embarazado && cuy.enCelo && cuy.genero != genero)
            {
                cuyController.agente.destination = cuy.transform.position;
                cuyController.buscandoPareja = true;
            }
        }
    }

    public void Crecimiento()
    {
        if (!creciendo)
        {
            tiempoEdad = day;
            creciendo = true;
        }

        if (edad == Edad.bebe)
        {    
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (day >= tiempoEdad + 2)
            {           
                edad = Edad.adulto;
                creciendo = false;
            }
        }

        if (edad == Edad.adulto)
        {       
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (day >= tiempoEdad + 15)
            {
                player.CuyesList.Remove(this);
                Destroy(this.gameObject);
            }
        }  
    }

    public void AgregarMaterial()
    {
        if (genero == Genero.macho)
        {
            materialCuy.material = materialMacho;
        }else{
            materialCuy.material = materialHembra;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cuy")
        {
            Cuy cuy = other.GetComponent<Cuy>();
            if (cuy.estado == Estado.sano && cuy.edad == Edad.adulto && !cuy.embarazado && cuy.enCelo && cuy.genero != genero)
            {
                if (genero == Genero.hembra)
                {
                    embarazado = true;
                    tiempoEmbarazo = day;
                }
                cuy.enCelo = false;
                cuyController.buscandoPareja = false;
            }
        }
    }
}
