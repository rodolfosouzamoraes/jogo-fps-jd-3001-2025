using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    [Header("Config Movimento")]
    public float velocidadeCaminhada; //Velocidade de caminhada do player
    public float velocidadeCorrida; //Velocidade de corrida do player
    public float forcaPulo; //Definir a força de subida do player
    public float forcaQueda; //Defini a força de decida do player
    public float valorConsumoStamina; //Define o valor da stamina que será consumida
    private Vector3 direcaoMovimentacao; //Definir a direção para onde o player deve ir
    private CharacterController playerControlador; //Variavel de controle do player
    private float velocidadeFrontal;
    private float velocidadeLateral;

    [Header("Config Camera")]
    public float velocidadeCamera; //Velocidade de rotação da camera
    public float limiteCameraAnguloX; //Definir o limite do angulo X que o jogador possa olhar
    private Camera playerCamera; //Variavel com a referencia da camera do jogo
    private float cameraRotacaoX; //Armazenar o valor do angulo X da camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar o Character Controller
        playerControlador = GetComponent<CharacterController>();

        //Definir uma direção inicial de zero
        direcaoMovimentacao = Vector3.zero;

        //Obter a referencia da camera principal da cena
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o jogo está pausado
        if (CanvasGameMng.Instance.JogoPausado == true) return;

        MovimentarXYZ();

        RotacionarY();

        RotacionarCameraX();
    }

    private void MovimentarXYZ()
    {
        //Obter a referencia da frente do player
        Vector3 frente = transform.TransformDirection(Vector3.forward);

        //Obter a referencia da direita do player
        Vector3 direita = transform.TransformDirection(Vector3.right);

        //Obter o input que faz o jogador correr
        bool estaCorrendo = Input.GetKey(KeyCode.LeftShift);

        //Verificar se tem stamina para poder correr
        if(CanvasGameMng.PnlStatusPlayer.TemStamina() == true)
        {
            //Calcular a velocidade de frontral
            velocidadeFrontal = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;
            
            //Calcular a velocidade de movimento lateral
            velocidadeLateral = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;

            //Consumir a stamina
            if (estaCorrendo == true) {
                CanvasGameMng.PnlStatusPlayer.ConsumirStamina(valorConsumoStamina);
            }
        }
        else
        {
            //Definir a velocidade de caminhada
            velocidadeFrontal = velocidadeCaminhada;
            velocidadeLateral = velocidadeCaminhada;
        }

        //Definir o movimento para frente ou para tras
        velocidadeFrontal *= Input.GetAxis("Vertical");

        
        //Definir o movimento para direita ou esquerda
        velocidadeLateral *= Input.GetAxis("Horizontal");

        //Definir uma direcao atual no eixo Y
        float direcaoY = direcaoMovimentacao.y;

        //Calcular a direção do player
        direcaoMovimentacao = (frente * velocidadeFrontal) + (direita * velocidadeLateral);

        //Verificar se o jogador está em contato com o chão para poder pular
        if (Input.GetButton("Jump") && playerControlador.isGrounded == true) {
            //Definir a direção em Y para efeturar o pulo
            direcaoMovimentacao.y = forcaPulo;
        }
        else
        {
            //Definir a direção de movimentação em Y 
            direcaoMovimentacao.y = direcaoY;
        }

        //Verficiar se o jogador não está no chão para poder fazer ele cair
        if (playerControlador.isGrounded == false) {
            //Apontar a direção em Y para baixo para fazer o jogador cair
            direcaoMovimentacao.y -= forcaQueda * Time.deltaTime;
        }
        
        //Movimentar o player
        playerControlador.Move(direcaoMovimentacao * Time.deltaTime);
    }

    private void RotacionarY()
    {
        //Obter o input X do mouse
        float rotacaoY = Input.GetAxis("Mouse X") * velocidadeCamera;

        //Rotacionar o corpo do player
        transform.rotation *= Quaternion.Euler(0, rotacaoY, 0);
    }

    private void RotacionarCameraX()
    {
        //Obter o input Y do mouse
        cameraRotacaoX += -Input.GetAxis("Mouse Y") * velocidadeCamera;

        //Limitar a rotação em X da camera
        cameraRotacaoX = Mathf.Clamp(cameraRotacaoX,-limiteCameraAnguloX,limiteCameraAnguloX);

        //Rotacionar a camera para a posição desejada em X
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotacaoX, 0, 0);
    }
}
