public class TwoSum
{
    /* Given 2 arrays of integers, return the 2 indexes of the 2 elements that add
    up to the target
    
    Example:
    -----------------------------
    int[] numbers = { 1, 2, 3, 4, 5 }, int target = 9
    return { 3, 4 }

    -----------------------------
    int[] numbers = { -1, 5, 10 }, int target = 3
    return null

    Important: Optimal time complexity
    */

    public void Test()
    {
        int[] numbers = { -1, 2, 3, -9 };
        int target = -10;
        int[] matchingPair = GetMatchingPair2(numbers, target);

        if (matchingPair == null)
        {
            Console.WriteLine($"Target {target} not found");
        }
        else
        {
            Console.WriteLine($"Target {target} found in index {matchingPair[0]}, {matchingPair[1]}");
        }
    }

    // ---- Brute Force Solution ----
    // Time complexity: O(n^2)
    // Space complexity: O(1)
    int[] GetMatchingPair1(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (numbers[i] + numbers[j] != target)
                {
                    continue;
                }

                return new int[] { i, j };
            }
        }

        return null;
    }

    // ---- Optimal Solution ----
    // Time complexity: O(n)
    // Space complexity: O(n)
    int[] GetMatchingPair2(int[] numbers, int target)
    {
        // Check if numbers is null or empty
        if (numbers == null || numbers.Length == 0)
        {
            return null;
        }

        // Create lookup where value = number and key = index
        Dictionary<int, int> indexLookup = new();
        
        // Iterate through numbers 
        for (int i = 0; i < numbers.Length; i++)
        {
            int complement = target - numbers[i];
            
            // Check if lookup contains complement (target - current number)
            if (indexLookup.ContainsKey(complement))
            {
                // If true, return current index and index of complement from lookup
                return new int[] { i, indexLookup[complement] };
            }
            
            // If false, add current number as key and current index as value to lookup
            indexLookup[numbers[i]] = i;
        }
        
        return null;
    }
}