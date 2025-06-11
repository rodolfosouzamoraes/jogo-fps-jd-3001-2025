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
}
