using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PnlLoja : MonoBehaviour
{
    public GameObject pnlLoja;
    public GameObject itemVenda;
    public AtributoVenda[] atributosVendas;
    public List<GameObject> listaItemVenda;
    public TextMeshProUGUI txtMoedas;
    public GameObject contentVenda;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pnlLoja.SetActive(false);

        //Iniciar a variavel da lista de itens
        listaItemVenda = new List<GameObject>();

        txtMoedas.text = $"{GameManager.DadosPlayer.moedas}";
    }

    public void ExibirPainelLoja()
    {
        pnlLoja.SetActive(true);
        CanvasGameMng.Instance.PausarJogo();
        
        ConfigurarItens();
    }
    public void OcultarPainelLoja()
    {
        pnlLoja.SetActive(false);
        CanvasGameMng.Instance.DespausarJogo();
    }

    private void ConfigurarItens()
    {
        txtMoedas.text = $"{GameManager.DadosPlayer.moedas}";

        //Percorrer a lista de itens e apagar todos os itens que lá existe
        foreach (var item in listaItemVenda)
        {
            Destroy(item);
        }
        //Limpar a lista
        listaItemVenda.Clear();

        //Percorrer a lista de atributos
        foreach (var atributo in atributosVendas)
        {
            //Verificar qual tipo do atributo para poder atualizar o valor da venda
            switch (atributo.id)
            {
                case EnumAtributoPlayer.mana:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_MANA_NV * GameManager.DadosPlayer.nvMana;
                    break;
                case EnumAtributoPlayer.vida:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_VIDA_NV * GameManager.DadosPlayer.nvVida;
                    break;
                case EnumAtributoPlayer.stamina:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_STAMINA_NV * GameManager.DadosPlayer.nvStamina;
                    break;
                case EnumAtributoPlayer.cajado:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_CAJADO_NV * GameManager.DadosPlayer.nvCajado;
                    break;
                case EnumAtributoPlayer.arco:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_ARCO_NV * GameManager.DadosPlayer.nvArco;
                    break;
                case EnumAtributoPlayer.flecha:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_FLECHAS * (int)(GameManager.DadosPlayer.arcoMax * 0.5f);
                    break;
                case EnumAtributoPlayer.consumoMana:
                    atributo.valorVenda = CustoInicialAtributo.PRECO_CONSUMO_MANA * (int)(GameManager.DadosPlayer.consumoMana * 1.5f);
                    break;
            }

            //Instanciar o item venda
            GameObject novoItemVenda = Instantiate(itemVenda, contentVenda.transform);

            //Configurar o item venda
            novoItemVenda.GetComponent<ItemVenda>().ConfigurarItem(
                atributo,
                GameManager.DadosPlayer.moedas
            );

            //Armazenar na lista
            listaItemVenda.Add(novoItemVenda);
        }
    }

    public void ComprarItem(EnumAtributoPlayer idItem, int valorItem)
    {
        //Consumir as moedas
        GameManager.ConsumirMoedas(valorItem);

        //Subir o nível ou aumentar limites dos atributos do player
        GameManager.SubirNivel(idItem);

        //Atualizar os dados dos itens na loja
        ConfigurarItens();

        //Atualizar a UI do player
        CanvasGameMng.PnlStatusPlayer.AtualizarTodosAtributosPlayer();
    }
}
