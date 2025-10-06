public class ReverseString
{
    public void Test()
    {
        Console.WriteLine(Reverse1("Hello my name is Jeff"));
    }

    string Reverse(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }

        char[] chars = s.ToCharArray();
        char[] reversed = new char[chars.Length];

        for (int i = 0; i < chars.Length; i++)
        {
            reversed[chars.Length - i - 1] = chars[i];
        }

        return new string(reversed);
    }

    string Reverse1(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }

        return new string(s.Reverse().ToArray());
    }
}