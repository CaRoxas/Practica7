using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Link : MonoBehaviour
{
    //VALORES
    float velocidad = 3f;
    float giro = 300f;

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

        //animator.SetFloat("", movy);
        //animator.SetFloat("", movy);
    }
}
