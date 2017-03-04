using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = new int[] { 3, 5, 9, 4, 7, 1, 0, 2, 6, 8};

            QuickSort(numberArray, 0, numberArray.Length-1);

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write( $"{numberArray[i]} ");
            }

            Console.ReadLine();
        }

        public static void QuickSort(int[] numbers, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = numbers[(i + j) / 2];

            while (i <= j)
            {
                while (numbers[i] < pivot)
                {
                    i++;
                }
                while (numbers[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    //swap
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;

                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuickSort(numbers, left, j);
            }
            if (right > i)
            {
                QuickSort(numbers, i, right);
            }
        }
    }
}
