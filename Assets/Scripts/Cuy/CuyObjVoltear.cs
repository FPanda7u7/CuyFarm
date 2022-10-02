using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyObjVoltear : MonoBehaviour
{

    public GameObject Player;

    public Cuy Cuy;

    public GameObject hambreAlert;
    public GameObject embarazoAlert;
    public GameObject vidaAlert;
    public GameObject celoAlert;

    //public GameObject stats;

    private void Awake()
    {

        Cuy = GetComponentInParent<Cuy>();
    }

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        hambreAlert.SetActive(Cuy.hambre);
        embarazoAlert.SetActive(Cuy.embarazado);
        
        if (Cuy.health < 3)
        {
            vidaAlert.SetActive(true);
        }
        else
        {
            vidaAlert.SetActive(false);
        }
        
        celoAlert.SetActive(Cuy.enCelo);

        //transform.LookAt(Player.transform);

        hambreAlert.transform.LookAt(Player.transform);
        embarazoAlert.transform.LookAt(Player.transform);
        vidaAlert.transform.LookAt(Player.transform);
        celoAlert.transform.LookAt(Player.transform);
    }
}
