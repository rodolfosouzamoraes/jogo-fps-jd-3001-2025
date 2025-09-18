using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public float valorDano;
    public void Atacar()
    {
        CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
    }
}
