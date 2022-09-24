using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuyController : MonoBehaviour
{
    public bool enCerca;
    public Vector3 objetivo;
    
    private NavMeshAgent agente;

    private GameObject gameObjectCerca;
    public Transform cerca;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        gameObjectCerca = GameObject.FindGameObjectWithTag("Cerca");
        if (gameObjectCerca != null)
        {
            cerca = gameObjectCerca.transform;
        }
    }

    void Start()
    {
        agente.stoppingDistance = 0;

        RandomPosition();    
    }

    void Update()
    {
        if (enCerca)
        {
            if (transform.position.x == objetivo.x && transform.position.z == objetivo.z)
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cerca")
        {
            enCerca = true;
        }else{
            enCerca = false;
        }
    }
}