using UnityEngine;

public class Controles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Captar a tecla do teclado para exibir a letra no console
        if (Input.GetKey(KeyCode.A)){
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q");
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E");
        }
    }
}
