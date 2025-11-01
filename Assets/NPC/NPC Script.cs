using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 0.1f;
    public LayerMask detectorPiso;
    public Transform detectorChao;
    public Transform detectorParede;
    public float raioDeteccao = 0.1f;

    private Rigidbody2D rb;
    private bool Direita = true;
    private Animator anim;
    public bool morto = false;

    public AudioClip hurt;
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Movimento
        rb.linearVelocity = new Vector2((Direita ? -1 : 1) * velocidade, rb.linearVelocity.y);

        if (anim != null)
            anim.SetBool("Andando", true);

        // Detecta queda ou parede para inverter direção
        // Raycasts
        bool temParede = Physics2D.Raycast(detectorParede.position, Direita ? Vector2.right : Vector2.left, 0.1f, detectorPiso);
        bool semChao = !Physics2D.Raycast(detectorChao.position, Vector2.down, 0.2f, detectorPiso);

        // Inverte direção se bater na parede ou não houver chão
        if (temParede || semChao)
        {
            Direita = !Direita;
            transform.Rotate(new Vector2(0, 180));
        }



    }

    public void Morrendo()
    {
        if(morto) return;
        morto = true;
        if (anim != null)
        {
            anim.SetTrigger("Morrendo");
        }
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Morte());
    }

        IEnumerator Morte()
    {
        yield return new WaitForSeconds(0.5f); // Substitua com a duração real da animação
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D outro)
{
    if (outro.CompareTag("Player"))
    {
        Debug.Log("Inimigo-Acertou");
        if (hurt != null) audioSource.PlayOneShot(hurt);
        StartCoroutine(MatarPlayer(outro.gameObject));
    }
}

IEnumerator MatarPlayer(GameObject player)
{

    // Ativa animação de morte
    Animator animPlayer = player.GetComponent<Animator>();
    if (animPlayer != null)
    {
        animPlayer.SetTrigger("Morrendo");
    }

    // Desativa movimentação do jogador
    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Espera a animação acabar 
    yield return new WaitForSeconds(1.3f);

    // Reinicia a cena
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}


}
