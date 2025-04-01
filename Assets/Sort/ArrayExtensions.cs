using System;
using Cysharp.Threading.Tasks;

namespace Sort
{
    public static class ArrayExtensions
    {
        public static void Refill(this int[] array)
        {
            var arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = UnityEngine.Random.Range(0, arrayLength);
            }
        }
        
        public static void Refill(this int[] array, int size)
        {
            array = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                array[i] = UnityEngine.Random.Range(0, size);
            }
        }
        
        public static async UniTaskVoid BubbleSortAsync(this int[] array, float delay)
        {
            var length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        await UniTask.Delay(TimeSpan.FromSeconds(delay));
                    }
                }
            }
        }

        /// <summary>
        /// The worst case for sort occurs when the array is in reverse order, requiring n(n−1)/2
        /// comparisons and swaps
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(this int[] array)
        {
            var length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }
}