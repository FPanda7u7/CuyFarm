using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuy : MonoBehaviour
{
    public enum Genero { macho, hembra};
    public enum Edad { bebe, adulto};
    public enum Estado { sano, enfermo};

    public Genero _genero;
    public Edad _edad;
    public Estado _estado;

    public int health = 3;

    public bool hambre;
    private float tmp_tiempoComer;
    public float tiempoComer;

    public bool enEsperaAparearse;
    public bool estadoEmbarazo;

    public bool creciendo;
    public float tiempoEdad;

    public bool enCelo;
    private bool tmp_enCelo;
    public float tiempoEnCelo;

    private float time;
    private float day;
    private float _hour;

    //public float embarazo;
    //public float tiempoHambre;
    //public float tiempoParaComer;
    //public float hacerPopo;

    //float deltaTime_edadTiempo;
    //float deltaTime_enCelo;
    //float deltaTime_embarazo;
    //float deltaTime_tiempoHambre;
    
    //float deltaTime_hacerPopo;

    void Start()
    {
        
    }

    
    void Update()
    {
        time = GameManager.instance.hour; // horas contadas
        day = GameManager.instance.day; // días contados
        _hour = GameManager.instance._hour; // 0 - 24 horas

        Salud();
        Crecimiento();
        Hambre();
        Aparearse();
        
    }

    public void Salud()
    {
        health = Mathf.Clamp(health, 0, 3);
        if (health == 0)
        {
            Debug.Log("Se murió");
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
        }
        else
        {
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
            }
            else
            {
                if (day >= tiempoEnCelo + 3)
                {
                    if (_estado == Estado.sano && _edad == Edad.adulto && !estadoEmbarazo)
                    {
                        enCelo = true;
                        tmp_enCelo = false;
                        Debug.Log("en celo");
                    }
                }
            }              
        }
        else
        {
            Debug.Log("Buscando pareja");
        }
    }

    public void Crecimiento()
    {
        if (!creciendo)
        {
            tiempoEdad = GameManager.instance.day;
            creciendo = true;
            Debug.Log("creciendo");
        }

        if (_edad == Edad.bebe)
        {    
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (GameManager.instance.day >= tiempoEdad + 2)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                _edad = Edad.adulto;
                creciendo = false;
            }
        }

        if (_edad == Edad.adulto)
        {       
            if (GameManager.instance.day >= tiempoEdad + 15)
            {
                Destroy(this.gameObject);
                Debug.Log("Se mimio de viejo");
            }
        }  
    }
}
