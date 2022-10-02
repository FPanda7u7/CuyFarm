using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificacionManager : MonoBehaviour
{
    public static NotificacionManager instance { get; private set; }

    public Notificacion[] notificaciones;

    public Notificacion n;

    public int index;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;    
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (this.gameObject.transform.childCount == 4)
        {
            Notificacion n = this.gameObject.transform.GetChild(0).GetComponent<Notificacion>();
            n.imageNoti.color = new Color(0.2f, 0.2f, 0.2f, 0.3f);
            n.textMessage.color = new Color(1f, 1f, 1f, 0.3f);
        }

        if (this.gameObject.transform.childCount == 5)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
        }    
    }

    public void CrearNotificacion(string notificacion)
    {
        Notificacion _n = Instantiate(n, this.transform);
        _n.message = notificacion;
    }
}
