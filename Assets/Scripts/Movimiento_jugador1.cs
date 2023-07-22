using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_jugador1 : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    public Vector2 input;

    private bool mirandoDerecha = true;
    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    private bool salto = false;
    

    
    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    [Header("Animacion")]
    private Animator animator;



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        


    }
    private void Update()
    {
        
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);
        animator.SetBool("enSuelo", enSuelo);


        if (Input.GetButtonDown("Jump"))
        {
            if (input.y >= 0)
            {
                salto = true;
            }
            else {
                DesactivarPlataformas();
                 }
        }

    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo",enSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        salto = false;
    }

    private void DesactivarPlataformas()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        foreach(Collider2D item in objetos)
        {
            PlatformEffector2D platformEffector2D = item.GetComponent<PlatformEffector2D>();
            if(platformEffector2D != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), item.GetComponent<Collider2D>(), true);
            }
        }
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
        
        saltar = false;
    }

   
    public void Rebote()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
