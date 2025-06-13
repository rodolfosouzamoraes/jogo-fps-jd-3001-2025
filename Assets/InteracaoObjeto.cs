using UnityEngine;

public class InteracaoObjeto : MonoBehaviour
{
    public GameObject pnlInteracao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pnlInteracao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
