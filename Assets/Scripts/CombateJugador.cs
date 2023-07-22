using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public int vida;

    public event EventHandler MuerteJugador;

    [SerializeField] public int maximoVida;
    private Slider slider;
    public Image relleno;


    

    private Animator animator;

    public void Start()
    {
        vida = maximoVida;
        animator = GetComponent<Animator>();

    }

    public void CambiarVidaActual(float cantidadVida)
    {
        animator.SetTrigger("Golpe");
    }

    

    public void TomarDano(int dano)
    {
        MovimientoCamara.Instance.MoverCamara(10, 10, 4f);
        vida -= dano;
        
        animator.SetTrigger("Golpe");
        if (vida <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
         
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetContact(0).normal.x >= 0.8 )
            {
 
             MuerteJugador?.Invoke(this, EventArgs.Empty);
             Destroy(gameObject);
            }
            else
            {
                if (collision.GetContact(0).normal.x <= -0.8)
                {

                    MuerteJugador?.Invoke(this, EventArgs.Empty);
                    Destroy(gameObject);
                }
            }
       }
                
            
    }
    public void Curar(int curacion)
    {
        if((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
    }

    void Update()
    {
        relleno.fillAmount = vida / maximoVida;
        
    }
}
