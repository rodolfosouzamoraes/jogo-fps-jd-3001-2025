using TMPro;
using UnityEngine;

public class ItemMana : MonoBehaviour
{
    public TextMeshProUGUI txtPorcentagemMana;
    private float valorMana;
    private float porcentagemMana;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sortear uma valor para mana
        valorMana = new System.Random().Next(25, 76);

        //Atualizar no texto o valor
        txtPorcentagemMana.text = $"{valorMana}%";

        //Definir a porcentagem da mana
        porcentagemMana = valorMana / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Acessar a mana do player e atribuir a porcentagem
            CanvasGameMng.PnlStatusPlayer.IncrementarMana(porcentagemMana);

            //Destruir mana
            Destroy(gameObject,Time.deltaTime);
        }
    }
}
