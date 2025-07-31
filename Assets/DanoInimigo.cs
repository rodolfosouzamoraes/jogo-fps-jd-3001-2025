using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public float vida; //Vida do inimigo
    
    public void EfetuarDano(float dano)
    {
        //Remover o valor do dano na vida
        vida -= dano;

        //Verificar se a vida acabou
        if (vida <= 0) { 
            
            //Destruir o inimigo
            Destroy(gameObject);
        }
    }
}
