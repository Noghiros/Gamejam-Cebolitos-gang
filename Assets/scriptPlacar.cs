using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  

public class PlacarInimigos : MonoBehaviour
{
    public TextMeshProUGUI textoPlacar;

    void Start()
    {
        AtualizarPlacar();
    }

    void Update()
    {
        AtualizarPlacar();
    }

    void AtualizarPlacar()
    {
        int inimigosRestantes = GameObject.FindGameObjectsWithTag("Inimigo").Length;
        textoPlacar.text = "Inimigos restantes: " + inimigosRestantes;

        if (inimigosRestantes == 0)
        {
            CarregarProximaCena();
        }
    }

    void CarregarProximaCena()
    {
        SceneManager.LoadScene("Braco"); 
    }
}
