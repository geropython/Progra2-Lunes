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

        //high Score values for the data Sorting
        [SerializeField] private int _highScoreValue;
        [SerializeField] private int _highScoreValue2;
        [SerializeField] private int _highScoreValue3;

        public int crystals;

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
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            highScore2.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
            highScore3.text = PlayerPrefs.GetInt("HighScore3", 0).ToString();


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
                    {
                        PlayerPrefs.SetInt("HighScore", crystals);
                        highScore.text = crystals.ToString();
                        _highScoreValue = PlayerPrefs.GetInt("HighScore");
                        //NO SABEMOS  CÓMO PASAR LOS HIGHSCORES ORDENADOS A UN DEBUG LOG EN CONSOLA UNITY.
                    }
                    else if (_currentScene == SceneManager.GetSceneByBuildIndex(2) &&
                             crystals > PlayerPrefs.GetInt("HighScore2", 0))
                    {
                        PlayerPrefs.SetInt("HighScore2", crystals);
                        highScore2.text = crystals.ToString();
                        _highScoreValue2 = PlayerPrefs.GetInt("HighScore2");
                        //NO SABEMOS  CÓMO PASAR LOS HIGHSCORES ORDENADOS A UN DEBUG LOG EN CONSOLA UNITY.
                    }

                    else if (_currentScene == SceneManager.GetSceneByBuildIndex(3) &&
                             crystals > PlayerPrefs.GetInt("HighScore3", 0))
                    {
                        PlayerPrefs.SetInt("HighScore3", crystals);
                        highScore3.text = crystals.ToString();
                        _highScoreValue3 = PlayerPrefs.GetInt("HighScore3");
                        //NO SABEMOS  CÓMO PASAR LOS HIGHSCORES ORDENADOS A UN DEBUG LOG EN CONSOLA UNITY.
                    }
                }
            }
        }

        [ContextMenu("crash UNITY")]
        private void QuickCrashing()
        {
            Recursivo.quickSort(_highScore, 0, _highScore.Length - 1);
            foreach (var score in _highScore) Debug.Log(score);
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
    }
}