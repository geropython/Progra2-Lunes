using UnityEngine;

namespace _Main._Resources.Scripts.Utilities.TDA.QuickSort
{
    public class Recursivo : MonoBehaviour
    {
        public class Player
        {
            public string name;
            public int score;

        }

        static public int Partition(Player[] arr, int left, int right)
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
        static public void quickSort(Player[] arr, int left, int right)
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

        static void imprimirVector(Player[] vec)
        {
            for (int i = 0; i < vec.Length; i++)
            {
                //Console.WriteLine(vec[i].name + " " + vec[i].score);
            }
        }

    
    
    
    }
}
