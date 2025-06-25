using UnityEngine;

public static class DBMng
{
    private const string PLAYER_DATA = "player-data";

    public static Player ObterDadosPlayer()
    {
        //Pegar a estrutura json que está salva na memória
        string json = PlayerPrefs.GetString(PLAYER_DATA);

        //Converter os dados para a classe Player
        Player player = JsonUtility.FromJson<Player>(json);

        //Verificar se existe um player salvo na memoria
        if(player == null)
        {
            //Criar um player padrão
            Player novoPlayer = new Player();
            novoPlayer.nome = "Renoir";
            novoPlayer.nvMana = 1;
            novoPlayer.nvVida = 1;
            novoPlayer.nvStamina = 1;
            novoPlayer.nvCajado = 1;
            novoPlayer.nvArco = 1;
            novoPlayer.manaMax = 500;
            novoPlayer.vidaMax = 250;
            novoPlayer.staminaMax = 100;
            novoPlayer.arcoMax = 25;
            novoPlayer.danoCajado = 50;
            novoPlayer.consumoMana = 25;
            novoPlayer.danoArco = 75;
            novoPlayer.moedas = 0;

            //Salvar o novo Player
            SalvarDadosPlayer(novoPlayer);

            return novoPlayer;
        }
        return player;
    }

    public static void SalvarDadosPlayer(Player novosDadosPlayer)
    {
        //Converter a estrutura da classe em json
        string json = JsonUtility.ToJson(novosDadosPlayer);

        //Salvar os dados na memoria
        PlayerPrefs.SetString(PLAYER_DATA, json);
    }

    public static Player SubirNivel(EnumAtributoPlayer atributoPlayer)
    {
        //Objter os dados atualizados do player
        Player player = ObterDadosPlayer();

        //Verificar qual atributo para subir de nível
        switch (atributoPlayer)
        {
            case EnumAtributoPlayer.mana:
                //Subir o nível da mana
                player.nvMana += 1;
                //Atualizar a mana Max
                player.manaMax *= 1.15f;
            break;
            case EnumAtributoPlayer.vida:
                player.nvVida += 1;
                player.vidaMax *= 1.10f;
            break;
            case EnumAtributoPlayer.stamina:
                player.nvStamina += 1;
                player.staminaMax *= 1.18f;
            break;
            case EnumAtributoPlayer.cajado:
                player.nvCajado += 1;
                player.danoCajado *= 1.05f;
            break;
            case EnumAtributoPlayer.arco:
                player.nvArco += 1;
                player.danoArco *= 1.07f;
            break;
            case EnumAtributoPlayer.flecha:
                player.arcoMax += 5;
            break;
            case EnumAtributoPlayer.consumoMana:
                player.consumoMana *= -1.03f;

                //Limitar o consumo minimo da mana
                if (player.consumoMana < 10)
                {
                    player.consumoMana = 10;
                }
            break;
        }

        //Salvar os dados
        SalvarDadosPlayer(player);

        //Retornar o player atualizado
        return player;
    }

    public static Player ConsumirMoedas(int valorCosumido)
    {
        Player player = ObterDadosPlayer();

        player.moedas -= valorCosumido;

        SalvarDadosPlayer(player);

        return player;
    }

    public static Player AdicionarMoedas(int valorInserido)
    {
        Player player = ObterDadosPlayer();

        player.moedas += valorInserido;

        SalvarDadosPlayer(player);

        return player;
    }
}
