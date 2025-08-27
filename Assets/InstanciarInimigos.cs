using UnityEngine;
using UnityEngine.AI;

public class InstanciarInimigos : MonoBehaviour
{
    public InimigoPorLevel[] inimigosPorLevel;//Inimigos e a quantidade que terá no inicio do jogo
    private int maximoInimigosNaFase;
    public float distanciaInicialParaNovoInimigo;//Distancia da qual o inimigo vai surgir em relação ao player
    public float distanciaParaNovoInimigo;//Distancia para quando o inimigo surgir novamente
    public float tempoEsperaNovoInimigo;//Tempo de espera para surgir um novo inimigo
    private float tempoProximoInimigo; //Tempo para surgir um novo inimigo
    private int totalInimigosInstanciados; //Armazenar o total de inimigos no jogo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Zerar os inimigos instanciados
        totalInimigosInstanciados = 0;

        //Definir o tempo de surgimento do proximo inimigo
        tempoProximoInimigo = tempoEsperaNovoInimigo + Time.timeSinceLevelLoad;

        //Instanciar os primeiros inimigos
        foreach (var inimigoLevel in inimigosPorLevel)
        {
            //Instanciar os inimigos na quantidade
            for (int i = 0; i < inimigoLevel.quantidade; i++)
            {
                InstanciarInimigo(distanciaInicialParaNovoInimigo, inimigoLevel.inimigo);
            }
        }

        //Definir o maximo de inimigos
        maximoInimigosNaFase = totalInimigosInstanciados;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se é possivel instanciar novos inimigos
        if ((totalInimigosInstanciados < maximoInimigosNaFase) &&
            Time.timeSinceLevelLoad > tempoProximoInimigo) 
        {
            //Atualizo o tempo para o proximo inimigo
            tempoProximoInimigo = Time.timeSinceLevelLoad + tempoEsperaNovoInimigo;

            //Instancio o inimigo novo
            int inimigoSorteado = new System.Random().Next(0,inimigosPorLevel.Length);
            InstanciarInimigo(distanciaParaNovoInimigo, inimigosPorLevel[inimigoSorteado].inimigo);
        }
    }

    private void InstanciarInimigo(float distancia, GameObject inimigo)
    {
        //Definir a posição em Z aleatóriamente onde o inimigo irá surgir
        float posicaoZ = Random.Range(
            PlayerMng.Instance.transform.position.z - distancia,
            PlayerMng.Instance.transform.position.z + distancia
        );

        //Definir a posição em X aleatóriamente onde o inimigo irá surgir
        float posicaoX = Random.Range(
            PlayerMng.Instance.transform.position.x - distancia,
            PlayerMng.Instance.transform.position.x + distancia
        );

        //Definir a posicao no NavMesh
        NavMeshHit posicaoFinal;
        NavMesh.SamplePosition(
            new Vector3(posicaoX, 0, posicaoZ),
            out posicaoFinal,
            Mathf.Infinity,
            1
        );

        //Instanciar o inimigo no jogo
        GameObject novoInimigo = Instantiate(inimigo);

        //Referenciar o novo inimigo com o script de instanciar
        novoInimigo.GetComponent<DanoInimigo>().ReferenciarInimigo(this);

        //Posicionar o inimigo na posição definida no navmesh
        NavMeshAgent agent = novoInimigo.GetComponent<NavMeshAgent>();
        agent.enabled = false; //Desativar a inteligencia do inimigo
        novoInimigo.transform.position = posicaoFinal.position;//Posicionar o inimigo
        agent.enabled = true; //Ativar a inteligencia novamente

        //Sortear uma rotação para o inimigo
        var rotacaoSorteada = Quaternion.Euler(0,new System.Random().Next(0,361),0);

        //Definir a rotação no inimigo
        novoInimigo.transform.rotation = rotacaoSorteada;

        //Incrementar o inimigo na variavel
        totalInimigosInstanciados++;
    }

    public void DecrementarInimigosInstanciados()
    {
        totalInimigosInstanciados--;
    }
}
