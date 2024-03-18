using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Link : MonoBehaviour
{
    //VALORES
    float velocidad = 3f;
    float giro = 300f;

    //GAMEOBJECTS
    public CinemachineVirtualCamera Eluno;
    public CinemachineVirtualCamera Eldos;
    public AudioSource Abril;

    //CONTROLADORES PERSONAJE
    Rigidbody rb;
    CharacterController controlador;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controlador = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movx = Input.GetAxis("Horizontal");
        float movy = Input.GetAxis("Vertical");

        transform.Rotate(0, movx * giro * Time.deltaTime, 0);

        Vector3 movimiento = transform.forward * movy;
        controlador.Move(movimiento * velocidad * Time.deltaTime);

        //El Input.GetAxis va de 0 a 1 entonces siendo 0 está moviendo/pulsando y 1 es cuando se deja de mover/pulsar
        if (movy > 0)
        {
            animator.SetBool("Campando",false);
        }
        else
        {
            animator.SetBool("Campando", true);
            
        }
        animator.SetFloat("Correr", movy);
        RaycastHit rayoposition;
        if (Physics.Raycast(transform.position, transform.forward, out rayoposition)) 
        {
            animator.SetBool("Cerquita", true);
        }
        else
        {
            animator.SetBool("Cerquita", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger")
        {
            Eluno.Priority = 10;
            Eldos.Priority = 11;
            Abril.Play();
        }
        else
        {
            Eluno.Priority = 11;
            Eldos.Priority = 10;
        }
    }

}
