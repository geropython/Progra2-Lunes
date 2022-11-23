using TMPro;
using UnityEngine;

namespace _Main._Resources.Scripts.Inventory
{
    public class Collector : MonoBehaviour
    {
        // poder integrar QuickSort con el collector / los cristales para llevar el conteo maximo de cada uno.
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private AudioSource pickUpSound;
    
        public int crystals;
    
        //public GameManager gameManager;
        private void Start()
        {
            crystals = 0;
        }

        private void Update()
        {
            scoreText.text = " : " + crystals;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            if (collectable != null)
            {
                collectable.Collect();
                pickUpSound.Play();
                crystals++; 
                // gameManager.CheckHighScore();
            }
        }
    }
}
