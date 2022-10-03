using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject despertarSFX;

    public int horas;
    public bool sonando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horas = (int)GameManager.instance._hour;

        if (horas == 7 && sonando)
        {
            Instantiate(despertarSFX);
            sonando = false;
            Debug.Log("Sonó Gallo");
            
        }
        if (horas == 8)
        {
            sonando = true;
        }
    }
}
