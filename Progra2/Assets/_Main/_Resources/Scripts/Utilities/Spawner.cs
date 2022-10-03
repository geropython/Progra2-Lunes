using System;
using UnityEngine;

namespace _Main._Resources.Scripts.Utilities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float timeToSpawn = 5f;
        private float _timeSinceSpawn;
        private ObjectPool _objectPool;
        
        void Start()
        {
            _objectPool = FindObjectOfType<ObjectPool>(); //----> gets the Object Pooling reference
        }

        void Update()
        {
            //Spawn Timer Settings and prefab to spawn.
            _timeSinceSpawn += Time.deltaTime;
            if (_timeSinceSpawn >= timeToSpawn)
            {
                GameObject newCritter = _objectPool.GetEnemy();
                newCritter.transform.position = this.transform.position;
                _timeSinceSpawn = 0f;
            }
        }
        
    }
}
