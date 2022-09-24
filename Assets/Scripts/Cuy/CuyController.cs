using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyController : MonoBehaviour
{
    public float speed = 5;

    public GameObject[] cercas = new GameObject[4];
    public GameObject cerca;
    public int cercaTarget;
    public bool choco;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (choco)
        {
            cercaTarget = Random.Range(0, 4);

            cerca = cercas[cercaTarget];            

            //transform.LookAt(new Vector3(cercas[cercaTarget].transform.position.x, cercas[cercaTarget].transform.position.z, cercas[cercaTarget].transform.position.z));

            transform.LookAt(cerca.transform.position);

            choco = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, cerca.transform.position, speed * Time.deltaTime);
        }

    }

}
