using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Enemy variables
    [SerializeField] private float speed;
    private Transform _player;
    [SerializeField] private float lineOfSight;
    private float _distance;
    [SerializeField] private int health;
    
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
            //Destroy Enemy
            Destroy(this.gameObject);
            

        }
       
        //Checks if the Player is in range, and then chase it.
        float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);

            if (distanceFromPlayer < lineOfSight)
            {
                transform.position =
                    Vector2.MoveTowards(this.transform.position, _player.position, speed * Time.deltaTime);
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
            Debug.Log("Enemie DAMAGED!");
        }
        
        
    }

