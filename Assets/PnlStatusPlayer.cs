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
}
