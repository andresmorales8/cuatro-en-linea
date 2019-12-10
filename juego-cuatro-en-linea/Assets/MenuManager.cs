using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
/// <summary>
/// Esta clase es utilizada cuando el boton start en la escena MenuManager-1 es presionado y carga la escena de juego SampleScene.
/// </summary>
public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// Función utilizada para cargar la escena de juego
    /// </summary>
    /// <param name="SampleScene">Recibe como parámetro un string como nombre de la escena</param>
    public void CargaNivel(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
