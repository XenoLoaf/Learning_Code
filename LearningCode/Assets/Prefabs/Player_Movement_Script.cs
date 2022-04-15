using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
   
   public float moveSpeed;
   
   private Rigidbody2D rb;
   private float moveDirection;
   private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if(moveDirection != 0) {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }
    }
}