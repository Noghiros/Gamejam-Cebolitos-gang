using UnityEngine;

public class ScriptPlataforma : MonoBehaviour
{
    private Vector2 PosIni;
    public float deslocamento = 2;
    private float cont = 0;

    public float Largura =1;
    public float Altura =1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    PosIni = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(cont) * Largura;
        float y = Mathf.Cos(cont) * Altura;

        transform.position = new Vector2(PosIni.x + x, PosIni.y + y);

        cont = cont + deslocamento * Time.deltaTime;
        
        if (cont > 2 * Mathf.PI)
            cont = cont - 2 * Mathf.PI;
        
    }
}
