using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 40;
    public float jumpSpeed = 50;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.1f;
    public float lowJumpMultiplier = 6f;
    public SpriteRenderer spriteRenderer;
    


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            
          
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            
        }
        if (Input.GetKey("space") && CheckGround.isGrounded) 
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += (fallMultiplier) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            }

            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += (lowJumpMultiplier) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            }
        }
    }
}
