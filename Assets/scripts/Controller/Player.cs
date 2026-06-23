using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class Player : MonoBehaviour, IDamageable
    {

        public string playerName;
        public int energy;
        public float health;
        public float maxHealth;

        [Header("Movimiento")]
        public float velocidad;
        public float gravedad;
        public float fuerzaSalto;

        [Header("Cámara y ratón")]
        public float sensibilidadRaton = 2f;
        public float limiteVerticalArriba = 80f;
        public float limiteVerticalAbajo = -80f;

        [Header("Referencias")]
        public Transform camara;

        private CharacterController controller;
        private Vector3 velocidadVertical;
        private float rotacionXActual = 0f;


        //daño
        public void RecibirDanio(float cantidad)
        {
            health -= cantidad;

            Debug.Log("Player recibio "+ cantidad + " de daño");
        }


        //Clases Ñyeehheheheh Ñ juajua jua tomen esto gringos "Ñ"
        public TipoClase claseActual;

        public void CambiarClase(TipoClase nuevaClase)
        {
            claseActual = nuevaClase;

            Debug.Log("la clase actual es: " + nuevaClase);
        }

        void Start()
        {

            controller = GetComponent<CharacterController>();


            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;


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
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

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

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.name} me colisiono");
            IInteractable interactable = other.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.interact();
            }

            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.RecibirDanio(10);
            }
        }
    }


    
}
    

