using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PnlStatusPlayer : MonoBehaviour
{
    [Header("Config Mana")]
    public float manaMax; //valor máximo da mana do player
    public float manaAtual; //valor atual da mana
    public float consumoConstante; //valor constante do consumo da mana
    public Slider manaSlider; //slider da mana    
    public TextMeshProUGUI txtMana; //TextMeshPro da mana

    [Header("Config Vida")]
    public float vidaMax;
    public float vidaAtual;
    public Slider vidaSlider;
    public TextMeshProUGUI txtVida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Defini a mana no maximo ao iniciar o jogo
        manaAtual = manaMax;

        //Configurar o slider
        manaSlider.maxValue = manaMax;
        manaSlider.minValue = 0;
        manaSlider.value = manaAtual;

        //Configurar o texto da mana
        txtMana.text = $"{manaAtual}/{manaMax}";

        //Defini a vida no maximo ao iniciar o jogo
        vidaAtual = vidaMax;

        //Configurar o slider
        vidaSlider.maxValue = vidaMax;
        vidaSlider.minValue = 0;
        vidaSlider.value = vidaAtual;

        //Configurar o texto da vida
        txtVida.text = $"{vidaAtual}/{vidaMax}";
    }

    public void ConsumirMana(float consumo)
    {
        //Verificar se tem mana
        if(manaAtual >= consumo)
        {
            //Remover a quantidade da mana
            manaAtual -= consumo;

            //Atualizar a mana
            AtualizarStatusMana();
        }
    }

    public void ConsumirManaConstante()
    {
        //Consumir a mana
        manaAtual -= consumoConstante * Time.deltaTime;

        //Verificar se a mana acabou
        if(manaAtual <= 0)
        {
            manaAtual = 0;
        }

        //Atualizar o status
        AtualizarStatusMana();
    }

    public bool TemMana(float consumo)
    {
        return manaAtual >= consumo;
    }

    public bool TemMana()
    {
        return manaAtual > 0;
    }

    private void AtualizarStatusMana()
    {
        manaSlider.value = manaAtual;
        txtMana.text = $"{(int)manaAtual}/{manaMax}";
    }

    public void IncrementarMana(float porcentagem)
    {
        manaAtual += manaMax * porcentagem;

        if(manaAtual > manaMax)
        {
            manaAtual = manaMax;
        }

        AtualizarStatusMana();
    }

    private void AtualizarStatusVida()
    {
        vidaSlider.value = vidaAtual;
        txtVida.text = $"{(int)vidaAtual}/{vidaMax}";
    }

    public void ConsumirVida(float valorConsumido)
    {
        vidaAtual -= valorConsumido;

        if(vidaAtual < 0)
        {
            vidaAtual = 0;
            //Game Over

        }

        AtualizarStatusVida();
    }

    public void IncrementarVida(float porcentagem)
    {
        vidaAtual += vidaMax * porcentagem;

        if(vidaAtual > vidaMax)
        {
            vidaAtual = vidaMax;
        }

        AtualizarStatusVida();
    }
}
