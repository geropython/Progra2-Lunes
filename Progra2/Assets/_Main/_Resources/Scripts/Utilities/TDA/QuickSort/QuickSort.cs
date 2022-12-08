using UnityEngine;

namespace _Main._Resources.Scripts.Utilities.TDA.QuickSort
{
    public class QuickSort : MonoBehaviour
    {
        [SerializeField] private int[] scores = { 10, 25, 50, 15, 30, 45, 5, 80, 90, 150 };

        private void Start()
        {
            //Recursivo.quickSort(scores, 0, scores.Length - 1);
            Debug.Log("QuickSort Initialized. Check For the values on the Inspector");
        }
    }
}