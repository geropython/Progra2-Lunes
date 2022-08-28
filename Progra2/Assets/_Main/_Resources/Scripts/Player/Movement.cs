using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Movement / Speed Variables
   [SerializeField] private float moveSpeed = 5;
   [SerializeField] Animator animator;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float moveLimiter = 0.7f;
 

    // Update is called once per frame
    void Update()
    {
        //Movement controller
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Directional Animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        //Diagonal movement Checker ( reduces the movement speed by 70%)
        if (movement.y != 0 && movement.x != 0) 
        {          
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}