using TMPro;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    public TextMeshProUGUI txtPorcentagemVida;
    private float valorVida;
    private float porcentagemVida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sortear uma valor para mana
        valorVida = new System.Random().Next(25, 76);

        //Atualizar no texto o valor
        txtPorcentagemVida.text = $"{valorVida}%";

        //Definir a porcentagem da mana
        porcentagemVida = valorVida / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Acessar a vida do player e atribuir a porcentagem
            CanvasGameMng.PnlStatusPlayer.IncrementarVida(porcentagemVida);

            //Destruir mana
            Destroy(gameObject, Time.deltaTime);
        }
    }
}
