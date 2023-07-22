using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hongo : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject efecto;
    private CombateJugador combateJugador;
    
    public GameObject GameOver;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
        combateJugador.MuerteJugador += ActivarMenu;

    }

    public void ActivarMenu(object sender, EventArgs e)
    {
        GameOver.SetActive(true);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
                if(other.GetContact(0).normal.y <= -0.9)
                {
                    animator.SetTrigger("Golpe");
                    other.gameObject.GetComponent<Movimiento_jugador1>().Rebote();
                }
                  
         }   
              
    }

    private void Update() { 

    
    }
    public void Golpe()
    {
        Instantiate(efecto, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
