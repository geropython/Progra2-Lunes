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

   //Attack Values and Variables
   public Transform attackPosition;
   [SerializeField] private float attackRange;
   [SerializeField] private Collider2D[] enemies;
   [SerializeField] private LayerMask enemiesHit;
   [SerializeField] private int damage;
 
   // NEW ATTACK TIMERS
   private float time;
   public float attackRate = 2f;
   private float nextAttackTime = 0f;
   
   
   //CACHÉ STRINGS
   private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
   private static readonly int Horizontal = Animator.StringToHash("Horizontal");
   private static readonly int Vertical = Animator.StringToHash("Vertical");
   private static readonly int Speed = Animator.StringToHash("Speed");
   private static readonly int Attack = Animator.StringToHash("Attack");

   //-----------------METHODS----------------------

    // Start is called before the first frame update
    void Start()
    {
        //Gets the rigidBody and Animator references of the player.
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
    }
    
    //COROUTINE FOR ATTACKING:
    IEnumerator PlayerAttack()
    {
        int  enemiesToDamage = Physics2D.OverlapCircleNonAlloc(attackPosition.position, attackRange, enemies, enemiesHit ); //CHECK THIS
        for (int i = 0; i < enemiesToDamage; i++)
        {
            enemies[i].GetComponent<EnemyScript>().TakeDamage(damage);
        }
        attackCounter = attackTime;
        animator.SetTrigger(Attack);  //---> New Animator attack system.
        isAttacking = true;

        yield return new WaitForSeconds(1);
    }

    void Update()
    {
        //Movement controller
        movement.x = Input.GetAxisRaw("Horizontal");     
        movement.y = Input.GetAxisRaw("Vertical");

        //-------------ATTACK FUNCTION---------------------------------
        
        //Attack Input and triggers Animation:

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= nextAttackTime)
            {
                //Starts the Coroutine of Attack:
                StartCoroutine(PlayerAttack());
                nextAttackTime = Time.time + 1f / attackRate;
              
            }

        }
        
        // Directional Animations
        animator.SetFloat(Horizontal, movement.x);      
        animator.SetFloat(Vertical, movement.y);
        animator.SetFloat(Speed, movement.sqrMagnitude);
       
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
    
    //DAMAGE PLAYER
    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager._playerHealth.Damage(damage);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    //HEAL PLAYER
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.Heal(healing);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
    
    //For The Attack Damage and Range Visualization:
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}