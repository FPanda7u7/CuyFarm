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
        if (player.inventario.comidaPlayer > 0)
        {
            player.hambre += 100;
            player.inventario.comidaPlayer--;
        }
    }

    public void Dormir()
    {
        if (GameManager.instance._hour >= 22)
        {         
            GameManager.instance.timeElapsed += 175f;
            interactuable.VolverGameplay();
        }else{
            Debug.Log("No puedes dormir");
        }

        player.fill = 2;
        player.barHambre.fillAmount = player.fill;
        player.CheckColor(player.barHambre);

        //Comer();
    }
}
