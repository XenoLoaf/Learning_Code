using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;

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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        audioSource.PlayOneShot(clip, volume);
        return;
    }
}