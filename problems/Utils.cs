public class Utils
{

    public static void PrintPuzzle(List<List<int>> puzzle)
    {
        Console.WriteLine("[");

        for (int r = 0; r < puzzle.Count; r++)
        {
            Console.Write("  [");

            for (int c = 0; c < puzzle[r].Count; c++)
            {
                Console.Write(puzzle[r][c]);

                if (c < puzzle[r].Count - 1)
                    Console.Write(", ");
            }

            Console.Write("]");

            if (r < puzzle.Count - 1)
                Console.WriteLine(",");
            else
                Console.WriteLine();
        }

        Console.WriteLine("]");
    }

    public static void Print2D(List<List<int>> grid)
    {
        Console.Write("[");

        for (int i = 0; i < grid.Count; i++)
        {
            Console.Write($"[{grid[i][0]}, {grid[i][1]}]");

            if (i < grid.Count - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("]");
    }

    public static void Print(List<int> list)
    {
        Console.Write("[");

        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i < list.Count - 1) Console.Write(", ");
        }

        Console.WriteLine("]");
    }
}