using System.Collections;
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

    [Header("Config Stamina")]
    public float staminaMax;
    public float staminaAtual;
    public Slider staminaSlider;
    public TextMeshProUGUI txtStamina;
    public float valorRestaurarStamina; //Definir o valor de restauração da stamina
    private bool permitirRestaurarStamina; //Define se pode restaurar a stamina
    private Coroutine coroutineStamina; //Armazena a coroutina para permitir voltar a restaurar a stamina


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfigurarMana();
        ConfigurarStamina();
        ConfigurarVida();
        ConfigurarConsumoManaConstante();
    }

    private void Update()
    {
        //Verificar se pode restaurar a stamina
        if(permitirRestaurarStamina == true)
        {
            RestaurarStamina();
        }
    }

    public void ConfigurarMana()
    {
        //Defini a mana no maximo ao iniciar o jogo
        manaMax = GameManager.DadosPlayer.manaMax;
        manaAtual = manaMax;

        //Configurar o slider
        manaSlider.maxValue = manaMax;
        manaSlider.minValue = 0;
        manaSlider.value = manaAtual;

        //Configurar o texto da mana
        txtMana.text = $"{(int)manaAtual}/{(int)manaMax}";
    }

    public void ConfigurarVida()
    {
        //Defini a vida no maximo ao iniciar o jogo
        vidaMax = GameManager.DadosPlayer.vidaMax;
        vidaAtual = vidaMax;

        //Configurar o slider
        vidaSlider.maxValue = vidaMax;
        vidaSlider.minValue = 0;
        vidaSlider.value = vidaAtual;

        //Configurar o texto da vida
        txtVida.text = $"{(int)vidaAtual}/{(int)vidaMax}";
    }

    public void ConfigurarStamina()
    {
        //Defini a stamina no maximo ao iniciar o jogo
        staminaMax = GameManager.DadosPlayer.staminaMax;
        staminaAtual = staminaMax;

        //Configurar o slider
        staminaSlider.maxValue = staminaMax;
        staminaSlider.minValue = 0;
        staminaSlider.value = staminaAtual;

        //Configurar o texto da stamina
        txtStamina.text = $"{(int)staminaAtual}/{(int)staminaMax}";

        //Definir para não restaurar no inicio a stamina
        permitirRestaurarStamina = false;
    }

    public void ConfigurarConsumoManaConstante()
    {
        //Obter o consumo padrão da mana e aumentar um pouco
        consumoConstante = GameManager.DadosPlayer.consumoMana * 1.5f;
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
        txtMana.text = $"{(int)manaAtual}/{(int)manaMax}";
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
        txtVida.text = $"{(int)vidaAtual}/{(int)vidaMax}";
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

    private void AtualizarStatusStamina()
    {
        staminaSlider.value = staminaAtual;
        txtStamina.text = $"{(int) staminaAtual}/{(int)staminaMax}";
    }

    private void RestaurarStamina()
    {
        staminaAtual += valorRestaurarStamina * Time.deltaTime;

        if(staminaAtual > staminaMax)
        {
            staminaAtual = staminaMax;
            permitirRestaurarStamina = false;
        }

        AtualizarStatusStamina();
    }

    private IEnumerator TempoRestauracaoStaminaCoroutine()
    {
        yield return new WaitForSeconds(3f);
        permitirRestaurarStamina = true;
    }

    public void ConsumirStamina(float valorConsumido)
    {
        //Não permitir a restauração da stamina
        permitirRestaurarStamina = false;
        
        //Decrementar a stamina
        staminaAtual -= valorConsumido * Time.deltaTime;

        //Verificar se acabou a stamina
        if (staminaAtual < 0) {
            staminaAtual = 0;
        }

        //Atualizar o status 
        AtualizarStatusStamina();

        //Verificar se existe alguma coroutina de stamina executando
        if (coroutineStamina != null) { 
            //Interromper essa coroutine
            StopCoroutine(coroutineStamina);
        }
        //Chamar a coroutina para começar a contar o tempo de restauração da stamina
        coroutineStamina = StartCoroutine(TempoRestauracaoStaminaCoroutine());
    }

    public bool TemStamina()
    {
        return staminaAtual > 0;
    }

    public void AtualizarTodosAtributosPlayer()
    {
        ConfigurarMana();
        ConfigurarVida();
        ConfigurarStamina();
        ConfigurarConsumoManaConstante();
    }
}
