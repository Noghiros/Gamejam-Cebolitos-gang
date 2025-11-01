using UnityEngine;

public class ParallaxScriptY : MonoBehaviour
{
    private float startPosY, comprimentoY;
    public GameObject cam;
    public float parallaxEffect; // velocidade do parallax

    // Start is called once before the first execution of Update
    void Start()
    {
        // Armazena a posição inicial Y do objeto e o comprimento no eixo Y
        startPosY = transform.position.y;
        comprimentoY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // A distância que a câmera se move no eixo Y
        float distance = cam.transform.position.y * parallaxEffect;

        // O movimento do objeto em relação ao parallax é dado pela diferença entre a posição da câmera e a posição inicial do objeto
        float movement = cam.transform.position.y * (1 - parallaxEffect);

        // Atualiza a posição do objeto somente no eixo Y
        transform.position = new Vector3(transform.position.x, startPosY + distance, transform.position.z);

        // Checa se o movimento ultrapassou o limite para um efeito de "scroll infinito"
        if (movement > startPosY + comprimentoY)
        {
            startPosY += comprimentoY;
        }
        else if (movement < startPosY - comprimentoY)
        {
            startPosY -= comprimentoY;
        }
    }
}
