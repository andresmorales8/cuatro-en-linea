using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

        public void RestartScene(string SceneToReStart)
        {
            SceneManager.LoadScene(SceneToReStart); // loads current scene
        }

}
