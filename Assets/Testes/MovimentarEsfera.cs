using UnityEngine;

public class MovimentarEsfera : MonoBehaviour
{
    public float velocidade;
    public float forca;
    private Rigidbody corpo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovimentarPelaForca();
    }

    private void MovimentarPelaPosicao()
    {
        //Devemos movimentar o objeto pela posição que ele está
        //Incrementando um valor de tempos em tempos para poder movimentar em uma direção
        transform.position += Vector3.forward * velocidade * Time.deltaTime;
    }

    private void MovimentarPeloTranslate()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }

    private void MovimentarPelaForca()
    {
        //Aplicar uma força ao corpo do objeto em determinada direção
        corpo.AddForce(Vector3.forward * forca * Time.deltaTime);
    }
}
