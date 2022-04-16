using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float ramp;
    public float moveSpeed;
    public float maxSpeed;
   
    private Rigidbody2D rb;
    private float moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
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
}