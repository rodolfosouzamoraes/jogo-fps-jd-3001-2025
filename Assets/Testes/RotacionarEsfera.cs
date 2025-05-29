using UnityEngine;

public class RotacionarEsfera : MonoBehaviour
{
    public float velocidade;
    private float angulo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotacionarPeloVector3();
    }

    public void RotacionarPeloRotate()
    {
        //Rotacionar o objeto pelo eixo
        transform.Rotate(0,-1 * velocidade * Time.deltaTime,0);
    }

    public void RotacionarPeloEuler()
    {
        //Incrementar a variavel angulo
        angulo += velocidade * Time.deltaTime;
        //Inserir esse angulo no comando para realizar a rotação
        transform.rotation = Quaternion.Euler(0, angulo, 0);
    }

    public void RotacionarPeloVector3()
    {
        //Incrementar a variavel angulo
        angulo += velocidade * Time.deltaTime;
        //Inserir esse angulo no comando do vector3
        transform.eulerAngles = new Vector3(0, angulo, 0);
    }
}
