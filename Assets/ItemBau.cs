using UnityEngine;

public class ItemBau : MonoBehaviour
{
    public GameObject pnlInteracao;
    public Animator animator;
    public ParticleSystem particulaBau;
    private bool bauAberto = false;

    public void AbrirBau()
    {
        if(bauAberto == false)
        {
            bauAberto = true;

            //Ativar animação do bau para abrir
            animator.SetTrigger("abrir");

            //Destruir o painel de interação
            Destroy(pnlInteracao);
        }
    }

    public void ObterItemBau()
    {
        //Armazenar a informação da coleta do item do bau
        CanvasGameMng.PnlStatusPlayer.IncrementarBausAbertos();

        //Emitir a particula
        particulaBau.Play();
    }

}
