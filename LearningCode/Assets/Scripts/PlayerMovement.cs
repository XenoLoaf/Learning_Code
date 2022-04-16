using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float ramp;
    public float moveSpeed;
    public float maxSpeed;
    public float JumpHeight;

    public bool isGrounded;
    public float RayCastLength;
   
    private Rigidbody2D rb;
    private float moveDirection;
    private CircleCollider2D circleCollider;

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

    void FixedUpdate(){
        moveDirection = Input.GetAxis("Horizontal");

        if(moveDirection != 1)
            if(moveDirection != -1)
                moveSpeed = 1;
                rb.velocity = new Vector2(0, rb.velocity.y);

        if(moveDirection != 0) 
            if(moveSpeed <= maxSpeed){
               rb.velocity = new Vector2(moveDirection * (moveSpeed += ramp*Time.deltaTime), rb.velocity.y); 
            }
        }

    void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, JumpHeight);
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