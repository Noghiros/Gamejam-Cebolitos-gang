using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScriptInicio : MonoBehaviour
{

    public void iniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
        Debug.Log("Iniciar jogo");
    }

    public void sair()
    {

        Application.Quit();
        Debug.Log("Sair do jogo");
    }

}
