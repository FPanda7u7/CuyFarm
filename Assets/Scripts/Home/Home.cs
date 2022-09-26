using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{

    public PlayerStats player;

    [SerializeField] private EdificioInteractable interactuable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Comer()
    {
        player.fill2 = 1;

        player.barHambre.fillAmount = player.fill2;
        player.CheckColor(player.barHambre);

        interactuable.VolverGameplay();
    }

    public void Dormir()
    {

        GameManager.instance.timeElapsed += 150;

        player.fill1 = 1.5f;
        player.barSleep.fillAmount = player.fill1;
        player.CheckColor(player.barSleep);

        player.fill2 = 2;
        player.barHambre.fillAmount = player.fill2;
        player.CheckColor(player.barHambre);

        //Comer();

        interactuable.VolverGameplay();
    }
}
