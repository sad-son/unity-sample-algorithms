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
        
        public static void Refill(ref int[] array, int size)
        {
            array = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                array[i] = UnityEngine.Random.Range(0, size);
            }
        }

        public static async UniTaskVoid MergeSortAsync(this int[] array, float delay)
        {
            await MergeSortAsync(array, 0, array.Length - 1, delay);
        }

        private static async UniTask MergeSortAsync(int[] array, int left, int right, float delay)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                await MergeAsync(array, left, mid, right, delay);
            }
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }
        
        private static void Merge(int[] array, int left, int mid, int right)
        {
            int leftLength = mid - left + 1;
            int rightLength = right - mid;
            
            int[] leftArray = new int[leftLength];
            int[] rightArray = new int[rightLength];

            for (int i = 0; i < leftLength; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int i = 0; i < rightLength; i++)
            {
                rightArray[i] = array[mid + 1 + i];
            }

            int k = left;
            int iLeft = 0, iRight = 0;

            while (iLeft < leftLength && iRight < rightLength)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                    array[k++] = leftArray[iLeft++];
                else
                    array[k++] = rightArray[iRight++];
            }
            
            while (iLeft < leftLength)
                array[k++] = leftArray[iLeft++];

            while (iRight < rightLength)
                array[k++] = rightArray[iRight++];
        }
        
        private static async UniTask MergeAsync(int[] array, int left, int mid, int right, float delay = 0f)
        {
            int leftLength = mid - left + 1;
            int rightLength = right - mid;
            
            int[] leftArray = new int[leftLength];
            int[] rightArray = new int[rightLength];

            for (int i = 0; i < leftLength; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int i = 0; i < rightLength; i++)
            {
                rightArray[i] = array[mid + 1 + i];
            }

            int k = left;
            int iLeft = 0, iRight = 0;

            while (iLeft < leftLength && iRight < rightLength)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                    array[k++] = leftArray[iLeft++];
                else
                    array[k++] = rightArray[iRight++];
                
                await UniTask.Delay(TimeSpan.FromSeconds(delay));
            }

            while (iLeft < leftLength)
            {
                array[k++] = leftArray[iLeft++];
                await UniTask.Delay(TimeSpan.FromSeconds(delay));
            }

            while (iRight < rightLength)
            {
                array[k++] = rightArray[iRight++];
                await UniTask.Delay(TimeSpan.FromSeconds(delay));
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