using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    //private PlayerUI playerUI;

    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;

    public TMP_Text message;

    void Start()
    {
        cam = Camera.main;
        //playerUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        message.text = string.Empty;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable i = hit.collider.GetComponent<Interactable>();
                //UIManager.instance.UpdateText(i.prompMessage);
                message.text = i.prompMessage;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    i.BaseInteract();
                }
            }
        }
    }
}
