using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDano;

    private float tiempoSiguienteDano;
    public GameObject burnt;
    private float tiempo;
    public event EventHandler DoughArdido;
    [SerializeField] private GameObject efecto;
    private Animator animator;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tiempoSiguienteDano -= Time.deltaTime;
            if (tiempoSiguienteDano <= 0)
            {
                other.GetComponent<CombateJugador>().TomarDano(5);
                tiempoSiguienteDano = tiempoEntreDano;
                DoughArdido?.Invoke(this, EventArgs.Empty);
                burnt.gameObject.SetActive(true);
                animator.SetTrigger("Burnt");
                other.gameObject.GetComponent<Animator>();
            }

            
        }

    }

    public void Burnt()
    {
        Instantiate(efecto, transform.position, transform.rotation);
        
    }

    public void ActivarMenu(object sender, EventArgs e)
        {
            burnt.gameObject.SetActive(true);
        }
    
}
