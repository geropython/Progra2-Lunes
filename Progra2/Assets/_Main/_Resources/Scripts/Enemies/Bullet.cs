
using System;
using _Main._Resources.Scripts.Player;
using _Main._Resources.Scripts.Utilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private GameObject _target;
   [SerializeField] private float speed;
   private Rigidbody2D _bulletRb;
   
   
   
   private void Start()
   {

      // Creates a Bullet and then moves it Towards the Player position.
      _bulletRb = GetComponent<Rigidbody2D>();
      _target = GameObject.FindGameObjectWithTag("Player");
      Vector2 moveDirection = (_target.transform.position - transform.position).normalized * speed;
      _bulletRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
      Destroy(this.gameObject, 2);
      
   }

   private void Update()
   {
      // Bullet Damage Player?¿
   }

   //Destroy Bullet when trigger with Player
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         Destroy(this.gameObject);
         Debug.Log("Bullet Destroyed");
      }
   }

  
   
}
