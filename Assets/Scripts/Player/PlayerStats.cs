using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<Cuy> CuyesList;
    
    public  int _money;

    void Start()
    {
        
    }

    

    void Update()
    {
        _money = GameManager.instance.moneyPlayer;
    }
}
