using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltoDoble : MonoBehaviour
{
    private Rigidbody2D rb2D;

     

    [Header("Salto")]

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;

    private bool enSuelo;
    private bool salto = false;
    [SerializeField] private int saltosExtraRestantes;
    [SerializeField] private int saltosExtra;

    private void Start() { 
        rb2D = GetComponent<Rigidbody2D>();
    
        
    }
    private void Update()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        if (enSuelo)
        {
            saltosExtraRestantes = saltosExtra;
        }

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        Movimiento(salto);
        salto = false;
     } 
    
    private void Movimiento(bool salto)
    {
        if (salto)
        {
                if (enSuelo)
                {
                Salto();
            }
            else
            {
                if(salto && saltosExtraRestantes > 0)
                {
                    Salto();
                    saltosExtraRestantes -= 1;
                }
            }
        }
    }


    private void Salto()
    {
        rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        salto = false;
    }


}
