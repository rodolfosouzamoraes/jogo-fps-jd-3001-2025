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

            //Colocar moeda provisoriamente
            DadosPlayer.moedas = 10000;
            DBMng.SalvarDadosPlayer(DadosPlayer);

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
    public static void ConsumirMoedas(int consumo)
    {
        DadosPlayer = DBMng.ConsumirMoedas(consumo);
    }
    public static void AdicionarMoedas(int moedas)
    {
        DadosPlayer = DBMng.AdicionarMoedas(moedas);
    }
}
