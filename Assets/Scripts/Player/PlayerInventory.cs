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
    
    public int selection;

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
            if (selection >= 2)
                selection = 0;
            else
                selection++;

            SelectItem(selection);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (selection <= 0)
                selection = 2;
            else
                selection--;

            SelectItem(selection);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selection = 0;
            SelectItem(selection);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selection = 1;
            SelectItem(selection);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selection = 2;
            SelectItem(selection);
        }
    }
}
