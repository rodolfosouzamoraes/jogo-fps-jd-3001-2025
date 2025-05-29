using UnityEngine;

public class MovimentarPlayerLabirinto : MonoBehaviour
{
    public float forca;
    private Rigidbody corpo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            corpo.AddForce(Vector3.left * forca * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            corpo.AddForce(Vector3.right * forca * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            corpo.AddForce(Vector3.forward * forca * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            corpo.AddForce(Vector3.back * forca * Time.deltaTime);
        }
        else
        {
            corpo.linearVelocity = Vector3.zero;
        }
    }
}
