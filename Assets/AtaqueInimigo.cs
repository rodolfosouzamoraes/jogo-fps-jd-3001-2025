using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public MovimentarInimigo movimentarInimigo;
    public float tempoEspera;
    private float tempoAtaque;
    public float valorDano;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtaque = Time.time + tempoEspera;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o inimigo estã vendo o player
        if (movimentarInimigo.estaVendoPlayer == true)
        {
            //verificar o tempo de ataque
            if (Time.time > tempoAtaque) {
                //Atualiza o tempo
                tempoAtaque = Time.time + tempoEspera;

                //Efetua o dano no player
                CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
            }
        }
    }
}
