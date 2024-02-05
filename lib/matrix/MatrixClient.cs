using static System.Console;

class MatrixClient
{
    public static void Execute() { 
        AddDemo();
        MultiplyDemo();
    }

    
    private static void AddDemo()
    {
        const int ROWS = 3;
        const int COLS = 3;
        int[,] A =
        {
            { 1, 3, 5 },
            { 7, 9, 11 },
            { 13, 15, 17 }
        };
        int[,] B =
        {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };
        int[,] C = new int[ROWS, COLS];

        WriteLine("矩陣相加：");
        WriteLine("[矩陣 A 的各個元素]");
        Matrix.PirntMatrix(A);
        WriteLine("[矩陣 B 的各個元素]");
        Matrix.PirntMatrix(B);
        Matrix.Add(A, B, C);
        WriteLine("[矩陣 A 與矩陣 B 的相加結果]");
        Matrix.PirntMatrix(C);
    }

    private static void MultiplyDemo()
    {
        int[,]? A = null, B = null;
        int M, N, P;
        var a = CreateMatrix(ref A, 'M', 'N');
        var b = CreateMatrix(ref B, 'N', 'P');
        M = a[0];
        N = a[1];
        P = b[1];
        int[,] C = new int[M, P];
        Matrix.Multiply(A, B, C, M, N, P);
        WriteLine("A * B 的結果是...");
        Matrix.PirntMatrix(C, M, P);
        ReadKey();
    }
    
    private static int[] CreateMatrix(ref int[,]? matrix, char rolName, char colName)
    {
        int X,
            Y,
            i,
            j;
        string tempStr;
        string matrixName = matrix?.ToString() ?? "";

        WriteLine($"請輸入矩陣 {matrixName} 的維數 ({rolName}, {colName})： ");
        Write($"請先輸入矩陣 {matrixName} 的 {rolName} 值： ");
        X = int.Parse(ReadLine() ?? "1");
        Write($"接著輸入矩陣 {matrixName} 的 {colName} 值： ");
        Y = int.Parse(ReadLine() ?? "1");

        matrix = new int[X, Y];
        WriteLine($"請輸入矩陣 {matrixName} 的各個元素");
        WriteLine("注意！每輸入一個值須按下 Enter 鍵確認輸入");
        for (i = 0; i < X; i++)
            for (j = 0; j < Y; j++)
            {
                Write($"{matrixName}[{i}, {j}] = ");
                tempStr = ReadLine() ?? "0";
                matrix[i, j] = int.Parse(tempStr);
            }

        return [X, Y];
    }
}
