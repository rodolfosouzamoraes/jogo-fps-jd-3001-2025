using UnityEngine;

public class MovimentarParaFrente : MonoBehaviour
{
    public float velocidade;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime); 
    }
}
