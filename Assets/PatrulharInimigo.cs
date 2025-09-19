using UnityEngine;
using UnityEngine.AI;

public class PatrulharInimigo : MovimentarInimigo
{
    public float distanciaParaNovoDestino; //Calcular a distancia para chegar até o destino
    private Vector3 destinoDoInimigo;//A posição onde o inimigo irá se posicionar
    private DanoInimigo danoInimigo; //Informações sobre se o inimigo sofreu danos
    private bool definiuDestinoInicial; //Dizer se o destino inicial foi definido
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referneciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Definir a velocidade
        agent.speed = velocidade;

        //Referenciar a variavel danoInimigo
        danoInimigo = GetComponent<DanoInimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        //Definir o destino inicial apenas uma vez
        if (definiuDestinoInicial == false) { 
            definiuDestinoInicial = true;
            destinoDoInimigo = transform.position;
        }

        //Verificar se o inimigo deve perseguir o player
        if (danoInimigo.sofreuDano == true) {
            PerseguirPlayer();
        }
        else
        {
            Patrulhar();
        }        
    }

    private void Patrulhar()
    {
        animacaoInimigo.PlayCorrendo();

        //Verificar se ele chegou ao destino
        if(Vector3.Distance(transform.position, destinoDoInimigo) < 0.005f)
        {
            //Gerar um novo destino
            //Definir a posição em Z aleatóriamente onde o inimigo irá surgir
            float posicaoZ = Random.Range(
                transform.position.z - distanciaParaNovoDestino,
                transform.position.z + distanciaParaNovoDestino
            );

            //Definir a posição em X aleatóriamente onde o inimigo irá surgir
            float posicaoX = Random.Range(
                transform.position.x - distanciaParaNovoDestino,
                transform.position.x + distanciaParaNovoDestino
            );

            //Definir a posicao no NavMesh
            NavMeshHit posicaoFinal;
            NavMesh.SamplePosition(
                new Vector3(posicaoX, 0, posicaoZ),
                out posicaoFinal,
                Mathf.Infinity,
                1
            );

            //Definir o novo destino
            destinoDoInimigo = new Vector3(
                posicaoFinal.position.x,
                transform.position.y,
                posicaoFinal.position.z
            );
        }
        else //mandar o ininigo para o destino
        {
            agent.destination = destinoDoInimigo;
        }
    }
}
