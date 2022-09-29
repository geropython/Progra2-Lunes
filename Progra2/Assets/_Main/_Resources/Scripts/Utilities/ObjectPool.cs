using System.Collections.Generic;
using UnityEngine;

namespace _Main._Resources.Scripts.Utilities
{
    public class ObjectPool : MonoBehaviour
    {

        [SerializeField] private GameObject enemyPrefab;
        private readonly Queue<GameObject> _enemyPool = new Queue<GameObject>();
        [SerializeField]
        private int poolStartSize = 5;

        private void Start()
        {
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                _enemyPool.Enqueue(enemy);    //Enqueue method
                enemy.SetActive(false);
            }
        }

        public GameObject GetEnemy()
        {
            if (_enemyPool.Count > 0)
            {
                GameObject enemy = _enemyPool.Dequeue();
                enemy.SetActive(true);
                return enemy;
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab);
                return enemy;
            }
        }

        public void ReturnEnemy(GameObject enemy)
        {
            _enemyPool.Enqueue(enemy);   //Enqueue Method
            enemy.SetActive(false);   //Deactivates the enemy
        }
    }
}
    