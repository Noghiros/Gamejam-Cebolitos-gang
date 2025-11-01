using UnityEditor;  
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptControladorJogo : MonoBehaviour
{
    private bool pausa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(2);
            }
            else
            {
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
            }
            pausa = !pausa;
        }

    }
}
