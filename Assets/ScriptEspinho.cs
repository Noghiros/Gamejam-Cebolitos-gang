using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Espinho : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Animator anim = outro.GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("Morrendo");

            Rigidbody2D rb = outro.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
            }

            StartCoroutine(ReiniciarCena(outro.gameObject));
        }
    }

    IEnumerator ReiniciarCena(GameObject jogador)
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
