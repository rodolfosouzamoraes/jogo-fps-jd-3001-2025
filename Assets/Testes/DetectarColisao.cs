using UnityEngine;

public class DetectarColisao : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Houve Colis�o!");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Havendo Colis�o!");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Saiu da Colis�o!");
    }
}
