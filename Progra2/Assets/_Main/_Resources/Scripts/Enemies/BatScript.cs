using System;
using _Main._Resources.Scripts.Utilities;
using UnityEngine;

namespace _Main._Resources.Scripts.Enemies
{
    public class BatScript : MonoBehaviour, IDamageable
    {
        [SerializeField] private float speed;
        private Transform _player;
        [SerializeField] private float lineOfSight;
        [SerializeField] private int health;
        [SerializeField] private AudioSource enemyDeath;
        
        //IDamageable
        public int Health { get; set; }
        public void Damage(int damage)
        {
            // health damage
            // health -= damage;
            // Debug.Log("Enemy DAMAGED!");
        }

        //METHODS--------------------------------
        void Start()
        {
            //Gets the reference to the player with a Tag.
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void Update()
        {
            //ENEMY HEALTH CHECK:
            if (health <= 0)
            {
                enemyDeath.Play();
                Die();
            }

            //Checks if the Player is in range, and then chase it.
            float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);

            if (distanceFromPlayer < lineOfSight)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, _player.position, speed * Time.deltaTime);
            }
        }

        //Gizmos for the enemy Line of sight view
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, lineOfSight);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log("Enemy DAMAGED!");
        }

        public void Die()
        {
            OnDisable();
        }

        private void OnDisable()
        {
            gameObject.SetActive(false);
        }

       
    }
}