using UnityEngine;
using UnityEngine.Events;

public class InteracaoObjeto : MonoBehaviour
{
    public GameObject pnlInteracao;
    public UnityEvent eventOn; //Variavel para armazenar função a ser executada
    public UnityEvent eventOff;
    private bool interruptor; //variavel para a lógica de ativar ou não os métodos
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pnlInteracao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o pnlInteracao esta ativo
        if (pnlInteracao.activeSelf == true) {
            //Verificar se clicou no botão de interação
            if (Input.GetButtonDown("Interacao"))
            {
                //Verificar o estado da variavel Interruptor
                if (interruptor == false)
                {
                    //Invocar o método do UnityEvent
                    eventOn.Invoke();
                }
                else
                {
                    eventOff.Invoke();
                }

                //Inverter a variavel Interruptor
                interruptor = !interruptor;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pnlInteracao.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pnlInteracao.SetActive(false);
            //Forçar o interruptor para false
            interruptor = false;
            //Invocar o UnityEvent de saida
            eventOff.Invoke();
        }
    }
}
