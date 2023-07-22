using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    public Image relleno;
    public float vidaActual;
    public float vidaMaxima;

    private Animator animator;
   
    void Awawe()
    {
        animator = GetComponent<Animator>();
    }


    public void CambiarVidaActual(float cantidadVida)
    {
        animator.SetTrigger("Golpe");
    }

    void Update()
    {
        relleno.fillAmount = vidaActual / vidaMaxima;
    }
        
}
