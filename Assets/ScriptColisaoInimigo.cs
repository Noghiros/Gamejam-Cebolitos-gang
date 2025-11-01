using UnityEngine;

public class ScriptColisaoInimigo : MonoBehaviour
{
    public GameObject inimigo;
    public float alturaMinimaParaMatar = 0.1f;

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbdJogador = colisao.gameObject.GetComponent<Rigidbody2D>();

            // Verifica se o jogador está acima do inimigo
            if (colisao.transform.position.y > transform.position.y + alturaMinimaParaMatar)
            {
                // Jogador mata o inimigo
                Destroy(inimigo);
                // Impulso para cima ao pular na cabeça
                rbdJogador.AddForce(Vector2.up * 250);
            }
            else
            {
                // Inimigo mata o jogador
                Destroy(colisao.gameObject);
            }
        }
    }
}
