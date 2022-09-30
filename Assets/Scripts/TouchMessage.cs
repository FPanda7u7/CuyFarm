using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TouchMessage : MonoBehaviour
{
    public string message;

    public GameObject _gameobject;
    public TextMeshProUGUI _text;

    void Start()
    {
        _text.text = message;
    }

    
    void Update()
    {
             
    }

    public void MostrarTexto()
    {
        _gameobject.SetActive(true);    
    }

    public void OcultarTexto() 
    {
        _gameobject.SetActive(false);
    }
    
}
