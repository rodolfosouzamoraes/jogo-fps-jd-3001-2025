using TMPro;
using UnityEngine;

public class ItemMana : MonoBehaviour
{
    public TextMeshProUGUI txtPorcentagemMana;
    private float porcentagemMana;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sortear uma valor para mana
        porcentagemMana = new System.Random().Next(25, 76);

        //Atualizar no texto o valor
        txtPorcentagemMana.text = $"{porcentagemMana}%";
    }

    // Update is called once per frame
    void Update()
    {
        OlharParaAlvo();
    }

    private void OlharParaAlvo()
    {
        //Definir a coordenada do objeto a ser visto
        Vector3 alvo = new Vector3(
            PlayerMng.Instance.transform.position.x,
            txtPorcentagemMana.transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o texto olhara para o jogador
        txtPorcentagemMana.transform.LookAt(alvo);
    }
}
