using UnityEngine;

public class RotacionarLoucamente : MonoBehaviour
{
    public float velocidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocidadeRotacao = Vector3.one * velocidade * Time.deltaTime;
        transform.Rotate(velocidadeRotacao);
    }
}
