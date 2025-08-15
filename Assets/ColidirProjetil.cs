using UnityEngine;

public class ColidirProjetil : MonoBehaviour
{
    public float valorDano; //Valor do dano que o player irá sofrer

    private void OnCollisionEnter(Collision collision)
    {
        //Verificar se colidiu com o player
        if (collision.gameObject.tag == "Player")
        {
            //Emitir dano no player
            CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
        }

        //Destruir o objeto ao entrar em contato com qualquer outro objeto
        Destroy(gameObject);
    }
}
