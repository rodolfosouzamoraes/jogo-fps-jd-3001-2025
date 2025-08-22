using UnityEngine;
using UnityEngine.AI;

public class RondaInimigo : MovimentarInimigo
{
    public float distanciaPerseguicao;
    private Vector3 posicaoInicial;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = velocidade;

        //Obter a posição inicial do inimigo
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Obter a distancia com o player
        float distancia = Vector3.Distance(transform.position,
            PlayerMng.Instance.transform.position);

        if (distancia < distanciaPerseguicao) {
            //Perseguir o player
            PerseguirPlayer();
        }
        else
        {
            //Mandar o inimigo para a posição inicial
            agent.destination = posicaoInicial;
        }
    }
}
