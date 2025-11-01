using UnityEngine;

public class ScriptHeroi : MonoBehaviour
{
    public LayerMask Mascara;
    public GameObject pe;
    private Rigidbody2D rbd;
    public float Velocidade = 4;
    public float Pulo = 350;
    private bool Chao;
    private bool direita = true;
    private Animator anim;
    public AudioClip sompulo;
    public AudioSource audioSource;


    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rbd.linearVelocity = new Vector2(x * Velocidade, rbd.linearVelocity.y);

        // Animação
        anim.SetBool("Correndo", x != 0);

        // Detectando chao 
        RaycastHit2D hit = Physics2D.Raycast(pe.transform.position, Vector2.down, 0.1f, Mascara);
        if (hit.collider != null)
        {
            Chao = true;
            transform.parent = hit.collider.transform;
            anim.SetBool("Pulando", false);

        }
        else
        {
            Chao = false;
            anim.SetBool("Pulando", true);
            transform.parent = null;
        }

        // Pular
        if (Input.GetKeyDown(KeyCode.UpArrow) && Chao)
        {
            audioSource.PlayOneShot(sompulo);
            rbd.AddForce(new Vector2(0, Pulo));
        }

        // Detectando direcao
        if (x < 0 && direita || x > 0 && !direita)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }



    }

    void OnTriggerEnter2D(Collider2D Morrendo)
    {
        Debug.Log("MORREU");
        anim.SetBool("Morrendo", true);
        rbd.linearVelocity = Vector2.zero;
        rbd.bodyType = RigidbodyType2D.Static;
            
    }



}
