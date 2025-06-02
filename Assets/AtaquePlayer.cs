using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public float consumoMana; //Valor do consumo da mana ao atacar

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AtacarCajado()
    {
        //Obter o input do usuário
        if(Input.GetAxis("Ataque") > 0)
        {
            //Verificar se tem mana
            if(CanvasGameMng.PnlStatusPlayer.TemMana(consumoMana) == true)
            {
                PlayerMng.AnimacaoPlayer.PlayAtaque();
            }            
        }
    }
}
