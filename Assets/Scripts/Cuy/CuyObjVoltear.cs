using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyObjVoltear : MonoBehaviour
{

    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
    }
}
