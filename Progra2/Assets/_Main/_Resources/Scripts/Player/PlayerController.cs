using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement / Speed Variables
   [SerializeField] private float moveSpeed = 5;
   [SerializeField] Animator animator;
   [SerializeField] HealthBarScript _healthBar;
   [SerializeField] private float attackTime = .50f;
   [SerializeField] private float attackCounter = .50f;

   public Rigidbody2D rb;
   private Vector2 movement;
   private float moveLimiter = 0.7f;
   private bool isAttacking;

    //-----------------METHODS----------------------

    // Start is called before the first frame update
    void Start()
    {
        //Gets the rigidBody and Animator references of the player.
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
      

        //Movement controller
        movement.x = Input.GetAxisRaw("Horizontal");     
        movement.y = Input.GetAxisRaw("Vertical");

        //-------------ATTACK FUNCTION---------------------------------
        //STOPS attack animation for Looping

        //Attack Input and triggers Animation:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            animator.SetBool("IsAttacking", true);
            isAttacking = true;

        }

        if (isAttacking)
        {         
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("IsAttacking", false);
                isAttacking = false;
            }
        }


        

        // Directional Animations
        animator.SetFloat("Horizontal", movement.x);      
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

       
        //-------------HEALTH AND DAMAGE FUNCTIONS--------------------
        //INPUT TESTING DAMAGE AND HEALTH SYSTEM
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHeal(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }
    

    //For Physics stuff
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerTakeDamage(10);
        }
    }

    //--------- HEALTH SYSTEM-------------
    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager._playerHealth.Damage(damage);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.Heal(healing);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
}