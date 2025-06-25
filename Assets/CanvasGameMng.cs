using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PnlStatusPlayer PnlStatusPlayer;
    public static PnlLoja PnlLoja;

    private void Awake()
    {
        if(Instance == null)
        {
            PnlStatusPlayer = GetComponent<PnlStatusPlayer>();
            PnlLoja = GetComponent<PnlLoja>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private bool jogoPausado;
    public bool JogoPausado
    {
        get { return jogoPausado; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausarJogo()
    {
        jogoPausado = true;
    }
    public void DespausarJogo()
    {
        jogoPausado = false;
    }
}
