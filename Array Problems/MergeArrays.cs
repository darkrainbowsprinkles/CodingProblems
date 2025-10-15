public class MergeArrays
{
    /*
    Merge 2 sorted arrays of integers
    */

    public void Test()
    {
        int[] array1 = { 0, 3, 4, 31 };
        int[] array2 = { 4, 6, 30 };
        int[] mergedArray = GetMergedArray(array1, array2);
        PrintArray(mergedArray);
    }

    void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write($"{number}, ");
        }

        Console.WriteLine();
    }

    // Time complexity: O(a + b)
    int[] GetMergedArray(int[] array1, int[] array2)
    {
        // Create new array with n1 + n2 length
        int[] mergedArray = new int[array1.Length + array2.Length];
        int i = 0, j = 0, k = 0;

        // Fill new array while arr1 and arr2 have elements
        while (i < array1.Length && j < array2.Length)
        {
            if (array1[i] <= array2[j])
            {
                mergedArray[k++] = array1[i++];
            }
            else
            {
                mergedArray[k++] = array2[j++];
            }
        }

        // Fill remaining elements in case of arrays of different lenghts
        while (i < array1.Length)
        {
            mergedArray[k++] = array1[i++];
        }

        while (j < array2.Length)
        {
            mergedArray[k++] = array2[j++];
        }

        return mergedArray;
    }
}