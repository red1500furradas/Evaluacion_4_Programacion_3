using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string playerName;
    public int energy;
    public int health;
    public int maxHealth;

    [Header("Movimiento")]
    public float velocidad;
    public float gravedad;
    public float fuerzaSalto;

    [Header("Cámara y ratón")]
    public float sensibilidadRaton = 2f;
    public float limiteVerticalArriba = 80f;   // grados máximos mirando hacia arriba
    public float limiteVerticalAbajo = -80f;   // grados máximos mirando hacia abajo

    [Header("Referencias")]
    public Transform camara;    // ← Arrastra aquí la cámara (debe ser hijo del player)

    private CharacterController controller;
    private Vector3 velocidadVertical;
    private float rotacionXActual = 0f;   // Para controlar la rotación vertical de la cámara

    void Start()
    {

        controller = GetComponent<CharacterController>();

        // Ocultar y bloquear cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Validamos que la cámara esté asignada
        if (camara == null)
        {
            Debug.LogError("¡No hay cámara asignada en el componente PlayerSimpleController!");
        }


    }

    void Update()
    {
        ProcesarRotacionRaton();
        ProcesarMovimientoHorizontal();
        ProcesarSaltoYGravedad();
        AplicarMovimiento();

       
    }

    private void ProcesarRotacionRaton()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadRaton;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadRaton;


        transform.Rotate(0, mouseX, 0);


        rotacionXActual -= mouseY;
        rotacionXActual = Mathf.Clamp(rotacionXActual, limiteVerticalAbajo, limiteVerticalArriba);


        if (camara != null)
        {
            camara.localRotation = Quaternion.Euler(rotacionXActual, 0, 0);
        }
    }


    private void ProcesarMovimientoHorizontal()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A / D
        float vertical = Input.GetAxisRaw("Vertical");   // W / S

        Vector3 direccion = transform.forward * vertical + transform.right * horizontal;


        if (direccion.magnitude > 1f)
        {
            direccion.Normalize();
        }


        movimientoHorizontal = direccion * velocidad;
    }

    private Vector3 movimientoHorizontal;

    private void ProcesarSaltoYGravedad()
    {

        if (controller.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }


        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadVertical.y = fuerzaSalto;
        }


        velocidadVertical.y += gravedad * Time.deltaTime;
    }

    private void AplicarMovimiento()
    {

        Vector3 movimientoFinal = movimientoHorizontal;
        movimientoFinal.y = velocidadVertical.y;


        controller.Move(movimientoFinal * Time.deltaTime);
    }
}
