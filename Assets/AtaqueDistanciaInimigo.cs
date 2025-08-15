using UnityEngine;

public class AtaqueDistanciaInimigo : MonoBehaviour
{
    public float distanciaDeAtaque;
    public GameObject projetil;
    public float tempoEspera;
    private float distancia;
    private float tempoAtaque;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtaque = Time.time + tempoEspera;
    }

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

            //Atacar o player
            AtirarProjetil();
        }
    }

    private void AtirarProjetil()
    {
        //verificar se está no tempo de atirar
        if(Time.time > tempoAtaque)
        {
            //Atualizar o tempo de ataque
            tempoAtaque = Time.time + tempoEspera;

            //Instancio o projetil
            GameObject novoProjetil = Instantiate(projetil);

            //Coloco o projetil na mesma posição e rotação do inimigo
            novoProjetil.transform.position = transform.position;
            novoProjetil.transform.rotation = transform.rotation;

            //Incremento uma distancia em z para o projetil aparecer na frente do inimigo
            novoProjetil.transform.Translate(new Vector3(0, 0, 1.24f));

        }
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
