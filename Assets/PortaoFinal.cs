using UnityEngine;

public class PortaoFinal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CanvasGameMng.PnlStatusPlayer.FimDeJogo();
        }
    }
}
