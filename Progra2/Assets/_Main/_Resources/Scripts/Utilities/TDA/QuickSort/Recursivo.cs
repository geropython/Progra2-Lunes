using System;
using System.Collections.Generic;

namespace _Main._Resources.Scripts.Utilities.TDA.QuickSort
{
    public static class Recursivo
    {
        private static readonly Random rng = new();


        public static int[] QuickSort(this int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot) i++;

                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
            return array;
        }


        private static void imprimirVector(int[] vec)
        {
            for (var i = 0; i < vec.Length; i++) Console.Write(vec[i] + " ");
        }


        public static void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}