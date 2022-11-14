
using System.Collections;
using _Main._Resources.Scripts.Enemies;
using _Main._Resources.Scripts.Utilities;
using Cinemachine;
using UnityEngine;

namespace _Main._Resources.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Movement / Speed Variables
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] Animator animator;
        [SerializeField] HealthBarScript _healthBar;
   
        // NEW ATTACK TIMERS
        private float _time;
        public float attackRate = 2f;
        private float _nextAttackTime;
   
        public Rigidbody2D rb;
        private Vector2 _movement;
        private float moveLimiter = 0.7f;
        
        //Attack Values and Variables
        public Transform attackPosition;
        [SerializeField] private float attackRange;
        
        //Enemy Layer´s / Collider references
         private Collider2D[] _enemies;
        [SerializeField] private LayerMask enemiesHit;
        [SerializeField] private int damage;
        
        //Interface:
        
   
        //AUDIO
        [SerializeField] private AudioSource hitSound;
   
        //CACHE STRINGS (Animations)
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");

        //-----------------METHODS----------------------

        void Start()
        {
            _enemies = new Collider2D[5];
            //Gets the rigidBody and Animator references of the player.
            rb = this.GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
        }
    
        //COROUTINE FOR ATTACKING:
        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator PlayerAttack()
        {
            animator.SetTrigger(Attack);
            //---> New Animator attack system.
          // Inicializar interfaz IDamageable ya seteada en Bat y en Slime Enemies.
            int  enemiesToDamage = Physics2D.OverlapCircleNonAlloc(attackPosition.position, attackRange, _enemies, enemiesHit ); 
            for (int i =0; i < enemiesToDamage; i++)
            {
                var currentEnemies= _enemies[i].GetComponent<BatScript>();
                

                if (currentEnemies != null)
                {
                    _enemies[i].GetComponent<BatScript>().TakeDamage(damage);
                    
                     // PAra que NO TIRE NULL REFERENCE; Enemy Slime no puede ser dañado.
                }
                
            }
            yield return new WaitForSeconds(1);  //Creación de Interfaz IDamageable  --->  Para Bat Script y Enemy Slime. ////OTRA ALTERNATIVA: Clase Base enemy.
        }

        void Update()
        {
            //Movement controller
            _movement.x = Input.GetAxisRaw("Horizontal");     
            _movement.y = Input.GetAxisRaw("Vertical");
            
            //-------------ATTACK FUNCTION---------------------------------
        
            //Attack Input and triggers Animation:

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time >= _nextAttackTime)
                {
                    _nextAttackTime = Time.time + 1f / attackRate;
                    //Starts the Coroutine of Attack:
                    StartCoroutine(PlayerAttack());
                  
                }
            }
        
            // Directional Animations
            animator.SetFloat(Horizontal, _movement.x);      
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
            
            //PLayer´s Rotation towards each input ( horizontal/ Vertical)
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
                Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat(LastHorizontal, Input.GetAxisRaw("Horizontal"));
                animator.SetFloat(LastVertical, Input.GetAxisRaw("Vertical"));
               
                
            }

            //-------------HEALTH AND DAMAGE FUNCTIONS--------------------
            //INPUT TESTING DAMAGE AND HEALTH SYSTEM
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayerTakeDamage(20);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                PlayerHeal(20);
            }
        }

        //For Physics stuff
        private void FixedUpdate()
        {
            //Diagonal movement Checker ( reduces the movement speed by 70%)
            if (_movement.y != 0 && _movement.x != 0) 
            {          
                _movement.x *= moveLimiter;
                _movement.y *= moveLimiter;
            }
            rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                hitSound.Play();
                PlayerTakeDamage(10);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Bullet"))
            {
                PlayerTakeDamage(5);
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
}