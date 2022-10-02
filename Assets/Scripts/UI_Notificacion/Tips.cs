using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tips : MonoBehaviour
{
    public GameObject contenedor;
    public GameObject ayuda;

    public TextMeshProUGUI message;

    public string[] mensajes;

    private int index;

    private bool init;
    private bool move;
    private bool run;
    private bool leer;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(!move && !init)
        {
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                StartCoroutine(SeMovio());          
            }
        }

        if(!run && move)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Corrio());
            }
        }

        if (run && move && !leer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;                 
            }
            if (index < mensajes.Length)
            {
                message.text = mensajes[index];
            }
            if (index >= mensajes.Length)
            {
                contenedor.SetActive(false);
                leer = true;
            }         
        }
    }

    IEnumerator SeMovio()
    {      
        init = true;
        yield return new WaitForSeconds(2f);
        message.text = "Bien hecho!";
        yield return new WaitForSeconds(2f);
        message.text = "Ten presionado shift para correr.";
        move = true;
    }

    IEnumerator Corrio()
    {      
        yield return new WaitForSeconds(2f);
        message.text = "Bien hecho!";
        yield return new WaitForSeconds(2f);
        run = true;
        ayuda.SetActive(true);
    }
}
