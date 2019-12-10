using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase es utilizada en la escena MenuManager-1 para girar los elementos del fondo de la escena.
/// </summary>
public class Rotate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0,0.5f,0));
    }
}
