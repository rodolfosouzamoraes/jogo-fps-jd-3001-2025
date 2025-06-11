using UnityEngine;

public class OlharParaPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Definir a coordenada do objeto a ser visto
        Vector3 alvo = new Vector3(
            PlayerMng.Instance.transform.position.x,
            transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o texto olhara para o jogador
        transform.LookAt(alvo);
    }
}
