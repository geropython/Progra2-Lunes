using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Enemy variables
    [SerializeField] private float speed;  
    private Transform player;
    [SerializeField] private float lineOfSight;
    private float distance;

    //METHODS--------------------------------
    void Start()
    {
        //Gets the reference to the player with a Tag.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        //Checks if the Player´s in range, and then chase it.
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
          
    }

    //Gizmos for the enemy Line of sight view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);

    }
}
