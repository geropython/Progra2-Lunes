using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement / Speed Variables
   [SerializeField] private float moveSpeed = 5;
   [SerializeField] Animator animator;
   [SerializeField] HealthBarScript _healthBar;

   public Rigidbody2D rb;
   private Vector2 movement;
   private float moveLimiter = 0.7f;

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

        // Directional Animations
        animator.SetFloat("Horizontal", movement.x);      
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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
    private void Awake()
    {
        
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