using _Main._Resources.Scripts.Utilities;
using _Main._Resources.Scripts.Utilities.TDA.QuickSort;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main._Resources.Scripts.Inventory
{
    public class NewCollector : MonoBehaviour
    {
        //poder integrar QuickSort con el collector / los cristales para llevar el conteo maximo de cada uno.
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScore;
        [SerializeField] private TextMeshProUGUI highScore3;
        [SerializeField] private TextMeshProUGUI highScore2;
        [SerializeField] private AudioSource pickUpSound;

        public int crystals;

        // high Score values for the data Sorting                      Pasar los valores estos 
        [SerializeField] private int _highScoreValue;
        [SerializeField] private int _highScoreValue2;
        [SerializeField] private int _highScoreValue3;

        private Scene _currentScene;


        //Array of high Score integers
        private int[] _highScore;

        [ContextMenu("RESET SCORES")]
        public void Reset() //RESETING HIGHSCORES FROM MAIN MENU ( PLAYER PREFS RESET)
        {
            PlayerPrefs.DeleteAll();
        }

        private void Start() //here we get the reference to the Player´s high score based on every Scene active
        {
            _currentScene = SceneManager.GetActiveScene();
            crystals = 0;
            _highScoreValue = PlayerPrefs.GetInt("HighScore", 0);
            _highScoreValue2 = PlayerPrefs.GetInt("HighScore2", 0);
            _highScoreValue3 = PlayerPrefs.GetInt("HighScore3", 0);


            UpdatePlayerPrefs();
            _highScore = new int [3];
            _highScore[0] = _highScoreValue;
            _highScore[1] = _highScoreValue2;
            _highScore[2] = _highScoreValue3;


            foreach (var score in _highScore) Debug.Log(score);
        }

        private void Update()
        {
            scoreText.text = " : " + crystals;
        }


        private void OnEnable()
        {
            SecondKeyItem.OnLevelChange += SaveHighScore;
            //Key item
            // otra key final
        }

        private void OnDisable()
        {
            SecondKeyItem.OnLevelChange -= SaveHighScore;
            //Key item
            // otra key final
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collectable = collision.GetComponent<ICollectable>();
            if (collectable != null)
            {
                collectable.Collect();
                pickUpSound.Play();
                crystals++;


                {
                    if (_currentScene == SceneManager.GetSceneByBuildIndex(1) &&
                        crystals > PlayerPrefs.GetInt("HighScore", 0))
                        highScore.text = crystals.ToString();

                    else if (_currentScene == SceneManager.GetSceneByBuildIndex(2) &&
                             crystals > PlayerPrefs.GetInt("HighScore2", 0))
                        highScore2.text = crystals.ToString();


                    else if (_currentScene == SceneManager.GetSceneByBuildIndex(3) &&
                             crystals > PlayerPrefs.GetInt("HighScore3", 0))
                        highScore3.text = crystals.ToString();
                }
            }
        }

        [ContextMenu("crash UNITY")]
        private void QuickCrashing()
        {
            var scoreArray = new[] { 75, 45, 71, 10, 5 }; // Cambiar los valores a mano por los highscoresValue.
            scoreArray.QuickSort(0, scoreArray.Length - 1);
            foreach (var score in scoreArray) Debug.Log(score);
        }


        private void UpdatePlayerPrefs() //DA ERROR
        {
            var a = PlayerPrefs.GetInt("HighScore", 0);
            var b = PlayerPrefs.GetInt("HighScore2", 0);
            var c = PlayerPrefs.GetInt("HighScore3", 0);
            _highScoreValue = a;
            _highScoreValue2 = b;
            _highScoreValue3 = c;
        }

        private void SaveHighScore()
        {
            // Leer los highscores
        }
    }
}