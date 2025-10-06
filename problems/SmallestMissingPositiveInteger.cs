public class SmallestMissingPositiveInteger
{
    /*
    Given an unsorted array of integers, find the smallest positive integer 
    not present in the array in O(n) time and O(1) extra space.

    Example:
    ----------------------------------
    Input: orderNumbers = [3, 4, -1, 1]
    Output 2

    We want the smallest positive missing integer.

    Start with [3, 4, -1, 1]
    - i=0: value 3 ⇒ swap with index 2 ⇒ [-1, 4, 3, 1]
    - i=0: value -1 is out of range ⇒ move on
    - i=1: value 4 ⇒ swap with index 3 ⇒ [-1, 1, 3, 4]
    - i=1: value 1 ⇒ swap with index 0 ⇒ [1, -1, 3, 4]
    - now 1 at index 0, 3 at 2, 4 at 3; -1 remains at index 1

    Scan from index 0:
    index 0 has 1 (correct), index 1 has -1 (not 2) ⇒ missing positive is 2

    */

    public void Test()
    {
        int[] numbers = { 3, 4, -1, 1 };
        Console.WriteLine(FindSmallestMissingPositive(numbers));
    }

    // ---- Optimal Solution ----
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    int FindSmallestMissingPositive(int[] numbers)
    {
        int n = numbers.Length;

        for (int i = 0; i < n; i++)
        {
            while (numbers[i] > 0 && numbers[i] <= n && numbers[i] != numbers[numbers[i] - 1])
            {
                (numbers[i], numbers[numbers[i] - 1]) = (numbers[numbers[i] - 1], numbers[i]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (numbers[i] != i + 1)
            {
                return i + 1;
            }
        }

        return numbers.Length + 1;
    }
}