public class CommonItems
{
    /* 
    Given 2 arrays, create a function that let's user know (true/false) whether these two
    arrays contain any common items.

    For Example:
    -----------------------------------------
    char[] array1 = { 'a', 'b', 'c', 'x' };
    char[] array2 = { 'z', 'y', 'i' };
    should return false
    -----------------------------------------
    char[] array1 = { 'a', 'b', 'c', 'x' };
    char[] array2 = { 'z', 'y', 'x' };
    should return true 
    
    2 parameters - arrays - no size limit,
    return true or false
    */

    public void Test()
    {
        char[] array1 = { 'a', 'b', 'c', 'x' };
        char[] array2 = { 'z', 'y', 'v' };

        Console.WriteLine(HasCommonItems2(null, array2));
    }
    
    
    // ----Brute Force Solution-----
    // Time complexity: O(a * b)
    // Space complexity: O(1)
    bool HasCommonItems1(char[] array1, char[] array2)
    {
        foreach (char firstLetter in array1)
        {
            foreach (char secondLetter in array2)
            {
                if (firstLetter == secondLetter)
                {
                    return true;
                }
            }
        }

        return false;
    }

    // ---- Optimal Solution ----
    // Time complexity: O(a + b)
    // Space complexity: O(a)
    bool HasCommonItems2(char[] array1, char[] array2)
    {
        // Check if array1 is null or empty
        if (array1 == null || array1.Length == 0)
        {
            return false;
        }

        // Check if array2 is null or empty
        if (array2 == null || array2.Length == 0)
        {
            return false;
        }

        // Loop through first array and create HashSet where elements == items in array
        HashSet<char> lettersLookup = new(array1);

        // Loop through the second array and check if item is in the HashSet
        foreach (char letter in array2)
        {
            if (lettersLookup.Contains(letter))
            {
                return true;
            }
        }

        return false;
    }
}