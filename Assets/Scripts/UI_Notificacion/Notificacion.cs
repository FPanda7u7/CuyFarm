using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Notificacion : MonoBehaviour
{
    public string message;
    public TextMeshProUGUI textMessage;
    public RawImage imageNoti;

    private void Start()
    {
        textMessage.text = message;
        Destroy(this.gameObject, 3.5f);
    }
}
