using System;
using System.Collections.Generic;
using System.Linq;

public class WordFinder
{
    private readonly char[,] matrix;
    private readonly int rows;
    private readonly int cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        var matrixList = matrix.ToList();
        rows = matrixList.Count;
        cols = matrixList[0].Length;
        this.matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this.matrix[i, j] = matrixList[i][j];
            }
        }
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var foundWords = new HashSet<string>();
        var wordCount = new Dictionary<string, int>();

        foreach (var word in wordstream.Distinct())
        {
            if (ExistsInMatrix(word))
            {
                foundWords.Add(word);
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }
        }

        return wordCount.OrderByDescending(x => x.Value)
                        .Take(10)
                        .Select(x => x.Key);
    }

    private bool ExistsInMatrix(string word)
    {
        for (int i = 0; i < rows; i++)
        {
            if (SearchHorizontal(i, word)) return true;
        }

        for (int j = 0; j < cols; j++)
        {
            if (SearchVertical(j, word)) return true;
        }

        return false;
    }

    private bool SearchHorizontal(int row, string word)
    {
        string rowStr = new string(Enumerable.Range(0, cols).Select(c => matrix[row, c]).ToArray());
        return rowStr.Contains(word);
    }

    private bool SearchVertical(int col, string word)
    {
        string colStr = new string(Enumerable.Range(0, rows).Select(r => matrix[r, col]).ToArray());
        return colStr.Contains(word);
    }
}
