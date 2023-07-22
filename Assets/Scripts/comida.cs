using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class comida : MonoBehaviour
{
    
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    public AudioSource clip;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            puntaje.SumarPuntos(cantidadPuntos);
            clip.Play();
            Destroy(gameObject, 0.5f);

            
        }
    }

   
}
