using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public GameObject _selection;

    public Transform[] slock;

    public int comidaCuy;
    public int comidaCuyEspecial;
    public int comidaPlayer;
    
    public int tmpSelection;

    public TextMeshProUGUI textComidaCuy;
    public TextMeshProUGUI textComidaCuyEspecial;
    public TextMeshProUGUI textComidaPlayer;

    private void Start()
    {
        
    }

    private void Update()
    {
        textComidaCuy.text = comidaCuy.ToString();
        textComidaCuyEspecial.text = comidaCuyEspecial.ToString();
        textComidaPlayer.text = comidaPlayer.ToString();

        InputSelection();     
    }

    public void SelectItem(int index)
    {
        _selection.transform.position = slock[index].position;
    }

    public void InputSelection()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (tmpSelection >= 2)
                tmpSelection = 0;
            else
                tmpSelection++;

            SelectItem(tmpSelection);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (tmpSelection <= 0)
                tmpSelection = 2;
            else
                tmpSelection--;

            SelectItem(tmpSelection);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tmpSelection = 0;
            SelectItem(tmpSelection);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tmpSelection = 1;
            SelectItem(tmpSelection);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tmpSelection = 2;
            SelectItem(tmpSelection);
        }
    }
}
