using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject creditos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Credits()
    {
        creditos.SetActive(true);
        menu.SetActive(false);
    }

    public void BackToMenu()
    {
        creditos.SetActive(false);
        menu.SetActive(true);
    }
}
