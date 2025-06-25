using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemVenda : MonoBehaviour
{
    public EnumAtributoPlayer idVenda;
    public TextMeshProUGUI txtNome;
    public TextMeshProUGUI txtValorVenda;
    public Image imgIconeVenda;
    public Image imgBotaoCompra;
    public Color botaoCompraOn;
    public Color botaoCompraOff;
    private int valorVenda;
    private int totalMoedas;
    private bool permitirCompra;
    public void ConfigurarItem(AtributoVenda venda, int moedasPlayer)
    {
        idVenda = venda.id;
        valorVenda = venda.valorVenda;
        totalMoedas = moedasPlayer;
        txtNome.text = venda.nome;
        txtValorVenda.text = $"{valorVenda}";
        imgIconeVenda.sprite = venda.icone;
        permitirCompra = totalMoedas >= valorVenda;

        //Verificar qual cor do botão colocar
        if (permitirCompra == true) { 
            imgBotaoCompra.color = botaoCompraOn;
        }
        else
        {
            imgBotaoCompra.color = botaoCompraOff;
        }
    }

    public void ComprarItem()
    {
        if (permitirCompra == false) return;

        //Comprar o item
        CanvasGameMng.PnlLoja.ComprarItem(idVenda, valorVenda);
    }
}
