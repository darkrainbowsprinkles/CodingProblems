// 9x9 grid
public class Sudoku
{
    public List<List<int>> GetSolvedPuzzle(List<List<int>> puzzle)
    {
        if (IsSolved(puzzle))
        {
            return puzzle;
        }

        List<List<int>> solvedPuzzle = [.. puzzle];

        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                if (solvedPuzzle[row][column] != 0)
                {
                    continue;
                }

                List<int> possible = GetPossibleNumbers(solvedPuzzle, row, column);

                if (possible.Count == 0)
                {
                    return [];
                }

                if (possible.Count == 1)
                {
                    solvedPuzzle[row][column] = possible[0];
                }
            }
        }

        return solvedPuzzle;
    }
    
    bool IsSolved(List<List<int>> puzzle)
    {
        foreach (var row in puzzle)
        {
            foreach (var cell in row)
            {
                if (cell == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    List<int> GetPossibleNumbers(List<List<int>> puzzle, int row, int column)
    {
        if (puzzle[row][column] != 0)
        {
            return [puzzle[row][column]];
        }

        HashSet<int> rowMissing = [.. GetMissing(puzzle[row])];
        HashSet<int> columnMissing = [.. GetMissing(GetColumnValues(puzzle, column))];
        HashSet<int> gridMissing = [.. GetMissing(GetSubgridValues(puzzle, row, column))];

        List<int> possible = [];

        for (int num = 1; num <= 9; num++)
        {
            if (rowMissing.Contains(num) && columnMissing.Contains(num) && gridMissing.Contains(num))
            {
                possible.Add(num);
            }
        }

        return possible;
    }

    List<int> GetColumnValues(List<List<int>> puzzle, int column)
    {
        List<int> columnValues = [];

        for (int r = 0; r < 9; r++)
        {
            columnValues.Add(puzzle[r][column]);
        }

        return columnValues;
    }

    List<int> GetSubgridValues(List<List<int>> puzzle, int row, int column)
    {
        List<int> gridValues = [];

        foreach (var coordinate in GetSubgridCoordinates(row, column))
        {
            gridValues.Add(puzzle[coordinate[0]][coordinate[1]]);
        }

        return gridValues;
    }

    List<List<int>> GetSubgridCoordinates(int row, int column)
    {
        int startRow = row - (row % 3);
        int startColumn = column - (column % 3);

        List<List<int>> coordinates = [];

        for (int r = startRow; r < startRow + 3; r++)
        {
            for (int c = startColumn; c < startColumn + 3; c++)
            {
                coordinates.Add([r, c]);
            }
        }

        return coordinates;
    }

    // Input : [5,4,2,0,1,8,0,6,3] between 1 and 9
    // Output: [7,9]
    List<int> GetMissing(List<int> nums)
    {
        bool[] present = new bool[10];

        for (int i = 0; i < nums.Count; i++)
        {
            int num = nums[i];

            if (num != 0)
            {
                present[num] = true;
            }
        }

        List<int> missing = [];

        for (int num = 1; num <= 9; num++)
        {
            if (!present[num])
            {
                missing.Add(num);
            }
        }

        return missing;
    }
}