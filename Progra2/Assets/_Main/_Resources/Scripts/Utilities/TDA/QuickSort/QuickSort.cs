using UnityEngine;

namespace _Main._Resources.Scripts.Utilities.TDA.QuickSort
{
    public  class QuickSort : MonoBehaviour
    {
        // methods to implement for Sorting Arrays or numbers depending on a Numeric variable.
      
         [SerializeField] private int[] scores = { 500, 200, 400, 100, 300 };
        
        private void Start()
        {
            
            SelectionSort(scores);      //Applies the Sorting method.
            
            Debug.Log("Sorted High Score is:" +string.Join("," ,scores));            // Debugs a message for the Sorting Scores in ascending order.
        }

        private void SelectionSort(int[] nums)       //Method for Re- organizing the numbers ( score in this case)
        {
            for (int i = 0; i < nums.Length -1; i++)
            {
                int smallestNumIndex = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[smallestNumIndex])
                        smallestNumIndex = j;
                }

                if (smallestNumIndex != i)
                {
                    (nums[i], nums[smallestNumIndex]) = (nums[smallestNumIndex], nums[i]);
                }
            }
        }

    }
}

