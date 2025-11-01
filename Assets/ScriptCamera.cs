using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    public GameObject heroi;
    public float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetY = 2.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(heroi.transform.position.x,
                                        heroi.transform.position.y+offsetY,-1);
    }
}
