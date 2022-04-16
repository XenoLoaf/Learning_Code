using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float JumpHeight;

    public bool isGrounded;
    public float RayCastLength;
   
    Rigidbody2D rb;
    public float moveDirection;
    CircleCollider2D circleCollider;

    public LayerMask ground;

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundDetection();
        Jump();
    }

    void FixedUpdate() 
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        if(moveDirection > 0.1f || moveDirection < -0.1f)
        {
            rb.AddForce(new Vector2 (moveDirection * moveSpeed, 0), ForceMode2D.Impulse);
        }
    }

    void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }
        else
        {
            return;
        }
    }

    void GroundDetection()
    {
        Debug.DrawRay(transform.position, Vector2.down * RayCastLength, Color.red);
        if(Physics2D.Raycast(transform.position, Vector2.down, RayCastLength, ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}