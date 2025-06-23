using System.Collections.Generic;
using UnityEngine;

public class PnlLoja : MonoBehaviour
{
    public GameObject pnlLoja;
    public GameObject itemVenda;
    public AtributoVenda[] atributosVendas;
    public List<GameObject> listaItemVenda;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pnlLoja.SetActive(false);
    }

    public void ExibirPainelLoja()
    {
        pnlLoja.SetActive(true);
        CanvasGameMng.Instance.PausarJogo();

        //Percorrer a lista de atributos
        foreach(var atributo in atributosVendas)
        {
            //Instanciar o item venda
            GameObject novoItemVenda = Instantiate(itemVenda, pnlLoja.transform);
            
            //Configurar o item venda
            novoItemVenda.GetComponent<ItemVenda>().ConfigurarItem(
                atributo,
                GameManager.DadosPlayer.moedas
            );
            
            //Armazenar na lista
            listaItemVenda.Add(novoItemVenda);
        }        
    }
    public void OcultarPainelLoja()
    {
        pnlLoja.SetActive(false);
        CanvasGameMng.Instance.DespausarJogo();
    }
}
