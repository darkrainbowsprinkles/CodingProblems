public class RomanToInt
{
    public void Test()
    {
        Console.WriteLine(GetRomanInt("III"));
    }

    int GetRomanInt(string romanNumber)
    {
        Dictionary<char, int> lookup = new()
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int sum = 0;
        int previousValue = 0;

        for (int i = romanNumber.Length - 1; i >= 0; i--)
        {
            int currentValue = lookup[romanNumber[i]];

            if (currentValue < previousValue)
            {
                sum -= currentValue;
            }
            else
            {
                sum += currentValue; 
            }
 
            previousValue = currentValue;
        }

        return sum;
    }
}