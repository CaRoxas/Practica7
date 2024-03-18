using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    //OBJETOS EXTERNOS
    public GameObject Link;
    public GameObject Pasadoor;

    //CONTROLADORES
    Animator animator;
    Rigidbody rb;
    Collider Collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject == Link)
        {
            animator.SetBool("Abierta", true);
            Pasadoor.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
