using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PnlStatusPlayer PnlStatusPlayer;

    private void Awake()
    {
        if(Instance == null)
        {
            PnlStatusPlayer = GetComponent<PnlStatusPlayer>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
