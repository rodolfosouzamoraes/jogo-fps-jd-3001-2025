using UnityEngine;

public class PlayerMng : MonoBehaviour
{
    public static PlayerMng Instance;
    public static MovimentarPlayer MovimentarPlayer;
    public static AnimacaoPlayer AnimacaoPlayer;
    public static AtaquePlayer AtaquePlayer;
    public static VisaoPlayer VisaoPlayer;

    private void Awake()
    {
        if(Instance == null)
        {
            MovimentarPlayer = GetComponent<MovimentarPlayer>();
            AnimacaoPlayer = GetComponent<AnimacaoPlayer>();
            AtaquePlayer = GetComponent<AtaquePlayer>();
            VisaoPlayer = GetComponentInChildren<VisaoPlayer>();
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
