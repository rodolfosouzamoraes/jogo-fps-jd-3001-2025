using UnityEngine;

public class AtaqueDistanciaInimigo : MonoBehaviour
{
    public SuporteAnimacaoInimigo animacaoInimigo;
    public float distanciaDeAtaque;
    public GameObject projetil;
    private float distancia;


    // Update is called once per frame
    void Update()
    {
        //Calcular a distancia entre o inimigo e o player
        distancia = Vector3.Distance(transform.position,
            PlayerMng.Instance.transform.position);

        //Verificar se a distancia é menor que a distancia de ataque
        if (distancia < distanciaDeAtaque) {
            //Olhar para o player
            OlharParaPlayer();

            animacaoInimigo.PlayAtacando();
        }
        else
        {
            animacaoInimigo.PlayParado();
        }
    }

    public void AtirarProjetil()
    {
        //Instancio o projetil
        GameObject novoProjetil = Instantiate(projetil);

        //Coloco o projetil na mesma posição e rotação do inimigo
        novoProjetil.transform.position = transform.position;
        novoProjetil.transform.rotation = transform.rotation;

        //Incremento uma distancia em z para o projetil aparecer na frente do inimigo
        novoProjetil.transform.Translate(new Vector3(0, 0, 1.24f));
    }
    private void OlharParaPlayer()
    {
        //Definir a coordenada do objeto a ser visto
        Vector3 alvo = new Vector3(
            PlayerMng.Instance.transform.position.x,
            transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o texto olhara para o jogador
        transform.LookAt(alvo);
    }
}
