using System.Collections.Generic;
using UnityEngine;

namespace _Main._Resources.Scripts.Utilities
{
    public class ObjectPool : MonoBehaviour
    {
        //utilizar Queue más óptimo, primeor en entrar, primero en salir. Utilizar interfaces IPooleable y si se puede hacerlo más dinámico para que se puedan poolear mas tipos de enemigos.
        //Prefabs to Pool / Queue  of Game objects of type :" enemyPool"
        [SerializeField] private GameObject enemyPrefab;
        private readonly Queue<GameObject> _enemyPool = new Queue<GameObject>();
       
        //Amount of prefabs that start within the game "Play Mode" in Pool Size.
        [SerializeField]
        private int poolStartSize = 5;

        private void Start()
        {
            for (int i = 0; i < poolStartSize; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                _enemyPool.Enqueue(enemy);    //Enqueue method
                enemy.SetActive(false);   //Sets the enemy prefab deactivated when "play Mode" Starts.
            }
        }

        public GameObject GetEnemy()
        {
            if (_enemyPool.Count > 0)
            {
                GameObject enemy = _enemyPool.Dequeue();
                enemy.SetActive(true);   //Activates the enemy prefab of the Pool Sizewhen the count is > to 0.
                return enemy;
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab);
                return enemy;           //Returns the enemy prefab
            }
        }

        public void ReturnEnemy(GameObject enemy)
        {
            _enemyPool.Enqueue(enemy);   //Enqueue Method
            enemy.SetActive(false);   //Deactivates the enemy
        }
    }
}
    