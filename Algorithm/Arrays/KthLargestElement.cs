using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    public class KthLargestElement
    {
        public int FindKthLargestElementInArray(int[] array, int firstIndex, int lastIndex, int kValue)
        {
            int arrayLength = array.Length - 1;

            int pivot = this.FindPivotValue(0, array.Length - 1, array);

            if(pivot > kValue)
            {
                return this.FindKthLargestElementInArray(array, 0, pivot - 1, kValue);
            }
            else if(pivot < kValue)
            {
                return this.FindKthLargestElementInArray(array, pivot + 1, array.Length - 1, kValue);
            }
            else
            {
                return array[pivot];
            }
        }

        private int FindPivotValue(int firstIndex, int indexLast, int[] array )
        {
            // alternatively, we can take even the mid point value
            int partitionIndex = new Random().Next(firstIndex, indexLast);
            
            // choose the partition value and swap with the last index value.
            int temp = array[partitionIndex];
            array[partitionIndex] = array[indexLast];
            array[indexLast] = temp;

            for(int i= firstIndex; i< indexLast; i++)
            {
                if(array[i] > array[indexLast])
                {
                    int temp1 = array[i];
                    array[i] = array[firstIndex];
                    array[firstIndex] = temp1;

                    firstIndex = firstIndex + 1;
                }
            }

            // Swap the parition back to originial place
            int temp2 = array[firstIndex];
            array[firstIndex] = array[indexLast];
            array[indexLast] = temp2;

            return firstIndex;
        }
    }
}
