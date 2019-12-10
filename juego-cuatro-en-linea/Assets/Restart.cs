using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Esta clase es utilizada en la escena SampleScene para recargar la escena cuando hay un ganador y se desea reiniciar el juego.
/// </summary>
public class Restart : MonoBehaviour
{
        /// <summary>
        /// Esta función es utilizada para recargar la escena
        /// </summary>
        /// <param name="SceneToReStart">Recibe como parámetro un string como nombre de la escena</param>
        public void RestartScene(string SceneToReStart)
        {
            SceneManager.LoadScene(SceneToReStart); 
        }

}
