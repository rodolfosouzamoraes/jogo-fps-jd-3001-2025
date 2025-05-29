using UnityEngine;

public class MovimentarCubo : MonoBehaviour
{
    public float velocidade;
    public float velocidadeRotacao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 1 * velocidadeRotacao * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -1 * velocidadeRotacao * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * velocidade * Time.deltaTime);
        }
    }
}
