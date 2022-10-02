using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuyController : MonoBehaviour
{
    public bool enCerca;
    public Vector3 objetivo;
    
    public NavMeshAgent agente;

    private GameObject gameObjectCerca;
    public Transform cerca;

    public bool buscandoPareja;
    public Cuy cuy;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        gameObjectCerca = GameObject.FindGameObjectWithTag("Cerca");
        if (gameObjectCerca != null)
        {
            cerca = gameObjectCerca.transform;
        }

        cuy = GetComponent<Cuy>();
    }

    void Start()
    {
        agente.stoppingDistance = 0;
        RandomPosition();    
    }

    void Update()
    {
        if (buscandoPareja)
        {
            return;
        }
        
        if (enCerca && agente.enabled == true)
        {
            if (Vector3.Distance(transform.position, objetivo) <= 0.215)
            {
                RandomPosition();
            }
            agente.destination = objetivo;
        }   
    }

    public void RandomPosition()
    {
        objetivo.x = Random.Range(cerca.localPosition.x - 9, cerca.localPosition.x + 9);
        //objetivo.y = cerca.position.y;
        objetivo.z = Random.Range(cerca.localPosition.z - 5, cerca.localPosition.z + 5);
    }

    public void stopIA()
    {
        agente.isStopped = true;
        agente.enabled = false;
    }

    public void playIA()
    {
        agente.enabled = true;
        agente.isStopped = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cerca")
        {
            enCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cerca")
        {
            enCerca = false;
        }
    }
}