using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruccion : MonoBehaviour
{
    public float tiempo;

    void Start()
    {
        Destroy(gameObject, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
