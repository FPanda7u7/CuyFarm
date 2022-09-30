using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }
 
    private void LateUpdate()      
    {
        transform.position = target.position;                                        
        transform.rotation = target.rotation;
    }
}
