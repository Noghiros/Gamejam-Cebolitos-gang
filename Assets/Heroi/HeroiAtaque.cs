using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HeroiAtaque : MonoBehaviour
{
    public AudioClip attack;
    public AudioSource audioSource;

    private float TempoEntreAtaques;
    public float ComeçoTempo;
    public float AreaAtaqueX;
    public float AreaAtaqueY;

    public Transform Ataquepos;
    public LayerMask DetectorInimigo;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (TempoEntreAtaques <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                anim.SetBool("Atacando", true);
                if (attack != null) audioSource.PlayOneShot(attack);
                Collider2D[] inimigos = Physics2D.OverlapAreaAll(Ataquepos.position - new Vector3(AreaAtaqueX / 2, AreaAtaqueX / 2, 0), Ataquepos.position + new Vector3(AreaAtaqueY / 2, AreaAtaqueY / 2, 0), DetectorInimigo);
            foreach (Collider2D inimigo in inimigos)
            {
                if (inimigo.CompareTag("Inimigo"))
                {
                    Inimigo inimigoScript = inimigo.GetComponent<Inimigo>();
                    
                        if (inimigoScript != null && !inimigoScript.morto)
                        {
                            inimigoScript.Morrendo();

                        }
                }
            }
            } 
            else
            {
                anim.SetBool("Atacando", false);
            }
            TempoEntreAtaques = ComeçoTempo;
        }
        else
        {
            TempoEntreAtaques -= Time.deltaTime;
        }
        


    }


}

