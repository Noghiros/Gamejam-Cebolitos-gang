using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScriptTutorial : MonoBehaviour
{

    public void Continuar()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(3);

    }

}
