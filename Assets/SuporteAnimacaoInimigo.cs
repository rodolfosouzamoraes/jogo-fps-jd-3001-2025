using UnityEngine;
using UnityEngine.Events;

public class SuporteAnimacaoInimigo : MonoBehaviour
{
    private Animator animator;
    public UnityEvent acionarAoAtacar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayParado()
    {
        animator.SetBool("Parado", true);
        animator.SetBool("Correndo", false);
        animator.SetBool("Atacando", false);
    }

    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
        animator.SetBool("Atacando", false);
    }

    public void PlayAtacando()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("Atacando", true);
    }

    public void EfetuarAtaque()
    {
        acionarAoAtacar.Invoke();
    }
}
