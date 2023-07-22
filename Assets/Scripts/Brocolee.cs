using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brocolee : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CombateJugador>().Curar(20);
            Destroy(gameObject);
        }
    }
}
