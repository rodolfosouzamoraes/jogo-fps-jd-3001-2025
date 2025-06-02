using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    public Animator animatorCajado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayAtaque()
    {
        animatorCajado.SetBool("Ataque", true);
        animatorCajado.SetBool("AtaqueConstante", false);
        animatorCajado.SetBool("Parado", false);
    }

    public void PlayAtaqueConstante()
    {
        animatorCajado.SetBool("Ataque", false);
        animatorCajado.SetBool("AtaqueConstante", true);
        animatorCajado.SetBool("Parado", false);
    }

    public void PlayParado()
    {
        animatorCajado.SetBool("Ataque", false);
        animatorCajado.SetBool("AtaqueConstante", false);
        animatorCajado.SetBool("Parado", true);
    }

    
}
