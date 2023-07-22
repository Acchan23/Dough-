using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuInicial : MonoBehaviour
{
   [SerializeField] public GameObject GameOver;
        private CombateJugador combateJugador;

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Start()
    {
        combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
        combateJugador.MuerteJugador += ActivarMenu;
            
    }

    public void ActivarMenu(object sender, EventArgs e)
    {
        GameOver.SetActive(true);
    }
    
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        
        Application.Quit();
    }

    public void Creditos()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu_Inicial");
    }
}
