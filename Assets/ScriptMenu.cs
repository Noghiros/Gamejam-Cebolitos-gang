using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{

    public void iniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(3);
    }

    public void sair()
    {

        Application.Quit();
        Debug.Log("Sair do jogo");
    }

}
