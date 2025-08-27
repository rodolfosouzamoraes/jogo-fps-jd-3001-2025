using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public float vida; //Vida do inimigo
    public bool sofreuDano; //Variavel para informar se o inimigo sofreu um dano
    private InstanciarInimigos controladorDeNovoInimigo;
    
    public void EfetuarDano(float dano)
    {
        //Remover o valor do dano na vida
        vida -= dano;

        //Verificar se a vida acabou
        if (vida <= 0) { 

            //Remover a referencia do inimigo
            controladorDeNovoInimigo.DecrementarInimigosInstanciados();
            
            //Destruir o inimigo
            Destroy(gameObject);
        }
    }

    public void ReferenciarInimigo(InstanciarInimigos referencia)
    {
        controladorDeNovoInimigo = referencia;
    }
}
