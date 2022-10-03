using _Main._Resources.Scripts.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main._Resources.Scripts.Utilities
{
    public class GameManager : MonoBehaviour
    {
        //Condition Variables
        [SerializeField] private string gameOver;
        [SerializeField] private string winGame;


        private DarkCrystal _darkCrystalScript;
        
        // Enemies or other classes´s health should work apart from this script, this works exclusively for the Player
  
        public static GameManager gameManager { get; private set; }
  
        //Referencing the Player´s Health controller
        public HealthController _playerHealth = new HealthController(100, 200);

        public GameObject darkCrystal;
        
        //SINGLETON TYPE
        void Awake()
        {
            if (gameManager != null && gameManager != this)
            {
            
                DontDestroyOnLoad(this);
            }
            else
            {
                gameManager = this;
            }

            _darkCrystalScript = darkCrystal.GetComponent<DarkCrystal>();
        }

        private void Update()
        {
            if (_playerHealth.Health <= 0)       
            {
                GameOver();
            }

            if (_darkCrystalScript.isCollected)
            {
                WinGame();
            }
        }

        public void WinGame()
        {
            SceneManager.LoadScene(winGame);           //Player wins when he collects the Dark crystal.
        }

        public void GameOver()
        {
            SceneManager.LoadScene(gameOver);           //Player lose when HP reaches 0.
        }
   

    }
}
