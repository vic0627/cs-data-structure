namespace Eight;

/* The above C# class implements a solution to the Eight Queens Puzzle by recursively determining valid
positions for queens on a chessboard without attacking each other. */
class Program
{
    private static readonly int EIGHT = 8;
    private static readonly int[] queen = new int[EIGHT];
    private static int number = 0;

    public static void Execute()
    {
        DecidePosition(0);
    }

    private static void PressEnter()
    {
        Write("\n\n");
        WriteLine("...按下 Enter 鍵繼續...");
        ReadLine();
    }

    private static void DecidePosition(int value)
    {
        int i = 0;
        while (i < EIGHT)
        {
            if (!Attack(i, value))
            {
                queen[value] = i;
                if (value == 7)
                    PrintTable();
                else
                    DecidePosition(value + 1);
            }
            i++;
        }
    }

    private static bool Attack(int row, int col)
    {
        int i = 0;
        bool atk = false;
        int offsetRow = 0,
            offsetCol = 0;
        while (!atk && i < col)
        {
            offsetCol = Math.Abs(i - col);
            offsetRow = Math.Abs(queen[i] - row);
            // 判斷兩皇后是否在同一列或同一對角線上
            if ((queen[i] == row) || (offsetRow == offsetCol))
                atk = true;
            i++;
        }
        return atk;
    }

    private static void PrintTable()
    {
        number += 1;
        WriteLine();
        Write($"八皇后問題的第{number}組解\n\t");
        for (int x = 0; x < EIGHT; x++)
        {
            for (int y = 0; y < EIGHT; y++)
                if (x == queen[y])
                    Write("<*>");
                else
                    Write("<->");
            Write("\n\t");
        }
        PressEnter();
    }
}
