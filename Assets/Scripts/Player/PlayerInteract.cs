using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    //private PlayerUI playerUI;

    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;

    void Start()
    {
        cam = Camera.main;
        //playerUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        //UIManager.instance.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable i = hit.collider.GetComponent<Interactable>();
                //UIManager.instance.UpdateText(i.prompMessage);
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    i.BaseInteract();
                }
            }
        }
    }
}
