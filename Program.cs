// TwoSum twoSum = new();
// twoSum.Test();

// SmallestMissingPositiveInteger smallest = new();
// smallest.Test();

// RomanToInt romanToInt = new();
// romanToInt.Test();

// MergeArrays mergeArrays = new();
// mergeArrays.Test();

// ReverseString reverseString = new();
// reverseString.Test();

Sudoku sudoku = new();

List<List<int>> puzzle = [
    [0,4,0,5,0,7,0,0,0],
    [3,5,0,0,0,0,2,7,1],
    [0,0,0,0,0,0,0,0,0],
    [5,0,0,2,0,0,9,4,0],
    [0,0,1,0,0,0,0,0,0],
    [7,0,2,0,0,0,8,0,0],
    [2,6,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,3,5,0],
    [0,0,4,0,9,0,0,0,0]
];

Utils.PrintPuzzle(sudoku.GetSolvedPuzzle(puzzle));
