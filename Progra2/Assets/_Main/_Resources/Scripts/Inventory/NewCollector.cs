using System;
using System.Collections.Generic;
using _Main._Resources.Scripts.Utilities.TDA.QuickSort;
using TMPro;
using UnityEngine;

namespace _Main._Resources.Scripts.Inventory
{
    public class NewCollector : MonoBehaviour
    {
        //poder integrar QuickSort con el collector / los cristales para llevar el conteo maximo de cada uno.
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScore;
        // [SerializeField] private TextMeshProUGUI highScore3;
        // [SerializeField] private TextMeshProUGUI highScore2;
        [SerializeField] private AudioSource pickUpSound;
        
        // Implementar Arboles
        public int crystals;
    
        //public GameManager gameManager;
        private void Start()
        {
            crystals = 0;
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            //highScore2.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
            //highScore3.text = PlayerPrefs.GetInt("HighScore3", 0).ToString();
            
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

                if (crystals > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore",crystals);
                    highScore.text = crystals.ToString();
                }
                   
            }

           
        }
        
        public void Reset()
        {
                PlayerPrefs.DeleteAll();
        }


        private int[] highscores = new int[3]; // valores que muestra en los score text
        List<TextMeshProUGUI> scores; // donde se muestran los scores (textmeshproUI)

        //guarda ultimo 
         //anterior1
        //anterior2
        //anterior3

// pido todos los valores para ordenarlos

        private void GetHighScores()
        {
            int highscore0 = PlayerPrefs.GetInt("HighScore0");
            int highscore1= PlayerPrefs.GetInt("HighScore1");
            int highscore2 = PlayerPrefs.GetInt("HighScore2");
            int highscore3 =PlayerPrefs.GetInt("HighScore3");

            List<int> highscorecheck = new List<int>(4);
            var lowest = 9999;
            for (int i = 0; i <highscorecheck.Count; i++)
            {
                int aux = 0;
                highscorecheck[i] = aux;
                if(aux <= lowest)
                {
                    lowest = aux;
                }
            }
            if (highscorecheck.Contains(lowest))
            {
                highscorecheck.Remove(lowest);
            }

            for (int i = 0; i < highscorecheck.Count; i++)
            {
                highscores[i]= (highscorecheck[i]);
            }
            
            Recursivo.quickSort(highscores,0,highscores.Length -1);
           Array.Reverse(highscores);
           
           for (int i = 0; i < highscores.Length; i++)
           {
               scores[i].text = highscores[i].ToString();
           }

           PlayerPrefs.SetInt("HighScore1", highscores[0]);
           PlayerPrefs.SetInt("HighScore2", highscores[1]);
           PlayerPrefs.SetInt("HighScore3", highscores[2]);
           
           
        }
        
// lista auxiliar para fijarme cual es el menor y borrarlo para que no se guarde ni muestre
       
// metodo para fijarme cual es el mas chico y sacarlo y guardarlos en su array para ser ordenado

//ordena el array con los 3 valores mas altos de highscore
// buscar como invertir el array array.reverse? quizas funciona

// muestra los valores en sus respectivas posiciones en la UI

// guarda esos 3 valores para poder seguir viendolos en otras partidas
   
    }
}
