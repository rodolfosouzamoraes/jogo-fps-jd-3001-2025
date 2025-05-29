using UnityEngine;

public class DetectarColisaoTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Houve Colisão Trigger.");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Havendo Colisão Trigger.");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu da Colisão Trigger.");
    }
}
