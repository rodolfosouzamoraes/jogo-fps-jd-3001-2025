using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public float consumoMana; //Valor do consumo da mana ao atacar
    public int idArma; //Id da arma selecionada
    public GameObject[] armas; //Armas do player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //configurar o consumo inicial da mana
        consumoMana = GameManager.DadosPlayer.consumoMana;

        //Selecionar o cajado ao iniciar o jogo
        SelecionarArma(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanvasGameMng.Instance.JogoPausado == true) return;

        //Verificar qual arma está ativa
        if (idArma == 0) { 
            //Atacar com o Cajado
            AtacarCajado();
        }
    }

    private void AtacarCajado()
    {
        //Obter o input do usuário
        if(Input.GetAxis("Ataque") > 0 && CanvasGameMng.PnlStatusPlayer.TemMana(consumoMana) == true)
        {
            PlayerMng.AnimacaoPlayer.PlayAtaque();
        }
        else if(Input.GetAxis("AtaqueConstante") > 0 && CanvasGameMng.PnlStatusPlayer.TemMana() == true)
        {
            PlayerMng.AnimacaoPlayer.PlayAtaqueConstante();
            //Consumir a mana constantemente
            CanvasGameMng.PnlStatusPlayer.ConsumirManaConstante();
        }
        else
        {
            PlayerMng.AnimacaoPlayer.PlayParado();
        }
    }

    private void SelecionarArma(int id)
    {
        //Desativar todas armas
        foreach (GameObject arma in armas) { 
            arma.SetActive(false);
        }

        //Ativar arma indicada
        armas[id].SetActive(true);
    }

    public void AtualizarConsumoMana()
    {
        consumoMana = GameManager.DadosPlayer.consumoMana;
    }
}
