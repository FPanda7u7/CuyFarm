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
    private int hour;     // horas contadas
    public int day;      // días contados
    private int _day;     // 0 - 7 días
    private int _hour;    // 0 - 24 horas

    public int health = 3;
    
    [Header("Alimentación")]
    public bool hambre;
    public float tiempoComer;
    private float tmp_tiempoComer;

    [Header("Embarazo")]
    public bool embarazado;
    public int tiempoEmbarazo;
    public int tmpEmbarazo;

    [Header("Celo")]
    public bool enCelo;
    private bool tmp_EnCelo;
    public int tmpDay = -1;
    public int timepoEnCelo;
    public int tmpEnCelo;
    
    [Header("Adicional")]
    public GameObject gameObjectCuy;
    public CuyController cuyController;

    public MeshRenderer materialCuy;
    public Material materialMacho;
    public Material materialHembra;   


    private void Awake()
    {
        cuyController = GetComponent<CuyController>();   
    }

    void Start()
    {
        AgregarMaterial();
        PlayerStats.instance.CuyesList.Add(this);
    }

    
    void Update()
    {
        hour = (int)GameManager.instance.hour; // horas contadas
        day = (int)GameManager.instance.day; // días contados
        _hour = (int)GameManager.instance._hour; // 0 - 24 horas
        _day = (int)GameManager.instance._day; // 0- 7 días
    
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
            PlayerStats.instance.CuyesList.Remove(this);
            NotificacionManager.instance.CrearNotificacion("Se murió un cuy :c");
            Destroy(this.gameObject);
        }
    }

    public void Hambre()
    {     
        if (hambre)
        {
            tiempoComer += Time.deltaTime;

            if (tiempoComer >= 50)
            {
                health--;
                hambre = false;
                tiempoComer = 0;
            }
        }else{
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
        if (!enCelo && tmpDay != day)
        {

            if (!tmp_EnCelo)
            {
                tmpEnCelo = day;
                tmp_EnCelo = true;
            }else{
                if (day >= tmpEnCelo + timepoEnCelo)
                {
                    if (estado == Estado.sano && edad == Edad.adulto && !embarazado)
                    {
                        enCelo = true;
                        tmp_EnCelo = false;
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
            if (day >= tmpEmbarazo + tiempoEmbarazo)
            {
                int cantidaHijos = Random.Range(3, 6);
                for (int i = 0; i < cantidaHijos; i++)
                {
                    GameObject cuyBebe = Instantiate(gameObjectCuy, transform.position, Quaternion.identity);
                    Cuy _cuyBebe = cuyBebe.GetComponent<Cuy>();
                    _cuyBebe.embarazado = false;
                    _cuyBebe.edad = Cuy.Edad.bebe;
                    _cuyBebe.genero = (Genero)Random.Range(0, 2);
                    
                }
                NotificacionManager.instance.CrearNotificacion("Un cuy dió a luz a " + cantidaHijos);
                embarazado = false;
                tmpEmbarazo = 0;
            }
        }
    }

    public void BuscarPareja()
    {
        for (int i = 0; i < PlayerStats.instance.CuyesList.Count; i++)
        {
            Cuy cuy = PlayerStats.instance.CuyesList[i].GetComponent<Cuy>();
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
                PlayerStats.instance.CuyesList.Remove(this);
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
}
