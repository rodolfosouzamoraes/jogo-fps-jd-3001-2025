using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static Player player;
    public static Player DadosPlayer
    {
        get { return player; }
        set { player = value; }
    }
    private void Awake()
    {
        if (Instance == null) {
            //Obter os dados do player
            DadosPlayer = DBMng.ObterDadosPlayer();

            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    
    public static void SubirNivel(EnumAtributoPlayer atributoPlayer)
    {
        DadosPlayer = DBMng.SubirNivel(atributoPlayer);
    }
    public static void AumentarFlechas()
    {
        DadosPlayer = DBMng.AumentarFlechas();
    }
    public static void DiminuirConsumoMana()
    {
        DadosPlayer = DBMng.DiminuirConsumoMana();
    }
    public static void ConsumirMoedas(int consumo)
    {
        DadosPlayer = DBMng.ConsumirMoedas(consumo);
    }
    public static void AdicionarMoedas(int moedas)
    {
        DadosPlayer = DBMng.AdicionarMoedas(moedas);
    }
}
