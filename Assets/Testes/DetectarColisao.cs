using UnityEngine;

public class DetectarColisao : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Houve Colisão!");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Havendo Colisão!");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Saiu da Colisão!");
    }
}
