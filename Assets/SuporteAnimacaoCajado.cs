using UnityEngine;

public class SuporteAnimacaoCajado : MonoBehaviour
{

    /// <summary>
    /// M�todo acessado pela anima��o do cajado
    /// </summary>
    public void ConsumirMana()
    {
        //Pegar o consumo da mana do player
        float mana = PlayerMng.AtaquePlayer.consumoMana;

        //Consumir a mana na UI
        CanvasGameMng.PnlStatusPlayer.ConsumirMana(mana);
    }
}
