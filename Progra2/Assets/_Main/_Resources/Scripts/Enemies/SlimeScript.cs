using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _Main._Resources.Scripts.Enemies
{
    public class SlimeScript : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Transform _player;
        [SerializeField] private float lineOfSight;
        [SerializeField] private int health;
        [SerializeField] private float shootingRange;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bulletParent;
        [SerializeField] private float fireRate;
        private float _nextFireTime;

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
                OnDisable();
            }

            //Checks if the Player is in range, and then chase it.
            float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);

            if (distanceFromPlayer < lineOfSight & distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, _player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && _nextFireTime < Time.time)
            {
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                _nextFireTime = Time.time + fireRate;
            }
        }

        //Gizmos for the enemy Line of sight view
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, lineOfSight);
            Gizmos.DrawWireSphere(transform.position, shootingRange);
        }
        
       

        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log("Enemy DAMAGED!");
        }

        private void OnDisable()
        {
            gameObject.SetActive(false);
        }
    }
}