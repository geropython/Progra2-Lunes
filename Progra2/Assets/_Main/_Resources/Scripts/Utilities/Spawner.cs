using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawn = 10f;
    private float timeSinceSpawn;
   private ObjectPool objectPool;
   [SerializeField]
   private GameObject prefab;


   private void Start()
   {
       objectPool = FindObjectOfType<ObjectPool>();
   }


   private void Update()
   {
       timeSinceSpawn += Time.deltaTime;
       if (timeSinceSpawn >= timeToSpawn)
       {
           GameObject newEnemy = objectPool.GetObject(prefab);
           newEnemy.transform.position = this.transform.position;
           timeSinceSpawn = 0f;
       }
   }
}
