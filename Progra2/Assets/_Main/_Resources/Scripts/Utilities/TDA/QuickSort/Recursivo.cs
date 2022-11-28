using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace _Main._Resources.Scripts.Utilities.TDA.QuickSort
{
    public class Recursivo : MonoBehaviour
    {

        [SerializeField] private int[] scores = { 10, 25, 50, 15, 30, 45, 5, 80, 90, 150 };
        private HighScore[] arrayHighScores = new HighScore[10];
        private Random random = new System.Random();

      
        
        public class HighScore
        {
            public string name;
            public int score;

        }

        static public int Partition(HighScore[] arr, int left, int right)
        {
            int pivot;
            int aux = (left + right) / 2;   //tomo el valor central del vector
            pivot = arr[aux].score;

            // en este ciclo debo dejar todos los valores menores al pivot
            // a la izquierda y los mayores a la derecha
            while (true)
            {
                while (arr[left].score < pivot)
                {
                    left++;
                }
                while (arr[right].score > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    (arr[right], arr[left]) = (arr[left], arr[right]);
                }
                else
                {
                    // este es el valor que devuelvo como proxima posicion de
                    // la particion en el siguiente paso del algoritmo
                    return right;
                }
            }
        }
        static public void quickSort(HighScore[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    // mitad del lado izquierdo del vector
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    // mitad del lado derecho del vector
                    quickSort(arr, pivot + 1, right);
                }
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        static void imprimirVector(HighScore[] vec)
        {
            for (int i = 0; i < vec.Length; i++)
            {
               Debug.Log(vec[i].name + " " + vec[i].score);
            }
        }

        public void Start()
        {
           
            Debug.Log("Inicializa QuickSort");
            for (int i = 0; i < 10; i++)
            {
                arrayHighScores[i] = new HighScore();
                arrayHighScores[i].name = "HighScore_" + i.ToString();
                arrayHighScores[i].score = random.Next(1, 100);
                
            }
            imprimirVector(arrayHighScores);
            quickSort(arrayHighScores, 0, arrayHighScores.Length -1);
            imprimirVector(arrayHighScores);
        }

        public void Update()
        {
           
           
        }
    }
}
