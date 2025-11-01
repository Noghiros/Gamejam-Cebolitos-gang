using UnityEngine;
using TMPro;

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
        textoPlacar.text = "Inimigos restantes: " + inimigosRestantes + inimigosRestantes +inimigosRestantes;
    }
}
