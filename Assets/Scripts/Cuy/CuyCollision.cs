using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyCollision : MonoBehaviour
{
    public Cuy cuy;
    public Cuy _cuy;

    private void Awake()
    {
        cuy = GetComponentInParent<Cuy>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cuy")
        {
            _cuy = other.GetComponent<Cuy>();
            //Debug.Log(gameObject.name + other.gameObject.name);

            if (/*cuy.estado == Estado.sano && */_cuy.edad == Cuy.Edad.adulto && !_cuy.embarazado && _cuy.enCelo && _cuy.genero != cuy.genero)
            {
                //Debug.Log("Colisionan");
                if (cuy.genero == Cuy.Genero.hembra)
                {
                    cuy.enCelo = false;
                    cuy.embarazado = true;
                    cuy.tmpEmbarazo = cuy.day;
                    cuy.cuyController.buscandoPareja = false;
                    cuy.tmpDay = cuy.day;

                    _cuy.enCelo = false;
                    _cuy.tmpDay = _cuy.day;
                    _cuy.cuyController.buscandoPareja = false;
                         
                }else{
                    cuy.enCelo = false;
                    cuy.tmpDay = cuy.day;
                    cuy.cuyController.buscandoPareja = false;

                    _cuy.enCelo = false;
                    _cuy.embarazado = true;
                    _cuy.tmpEmbarazo = cuy.day;
                    _cuy.cuyController.buscandoPareja = false;
                    _cuy.tmpDay = _cuy.day;
                }
                
            }
        }
    }
}
