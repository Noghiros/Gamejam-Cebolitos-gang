using UnityEngine;

public class ParallaxScriptX : MonoBehaviour
{
    private float startPos, largura;
    public GameObject cam;
    public float parallaxEffect; //velocidade do parallax

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        // 0 - move com a camera
        // 1 - não move
        // 0.5 - move metade da velocidade da camera
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    // infinito scroll 
        if (movement > startPos + largura)
        {
            startPos += largura;
        }
        else if (movement < startPos - largura)
        {
            startPos -= largura;
        }
   
    } 
}
