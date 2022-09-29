using _Main._Resources.Scripts.Utilities;
using UnityEngine;

namespace _Main._Resources.Scripts.Enemies
{
    public class EnemyReturn : MonoBehaviour
    {
        private ObjectPool _objectPool;
        // This script is needed to return the enemy to the Pool!
        private void Start()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }

        private void OnDisable()
        {
            if(_objectPool != null)
                _objectPool.ReturnEnemy(this.gameObject);
        }
        
        
    }
}