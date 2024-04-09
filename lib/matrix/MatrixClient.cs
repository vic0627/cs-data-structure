using static System.Console;

class MatrixClient
{
    public static void Execute()
    {
        // AddDemo();
        // MultiplyDemo();
        // TransposeDemo();
        // SparseDemo();
        UpperTriangular();
        LowerTriangular();
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
        int[,]? A = null,
            B = null;
        int M,
            N,
            P;
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

        int[] point = { X, Y };
        return point;
    }

    private static void TransposeDemo()
    {
        int M,
            N;
        int[,]? mtx = null;

        var rowAndCol = CreateMatrix(ref mtx, 'M', 'N');

        if (mtx == null)
        {
            WriteLine("矩陣未正確初始化");
            return;
        }

        M = rowAndCol[0];
        N = rowAndCol[1];

        WriteLine("輸入矩陣內容為...");
        Matrix.PirntMatrix(mtx, M, N);

        int[,] _mtx = Matrix.Transpose(mtx);
        WriteLine("轉置矩陣內容為...");
        Matrix.PirntMatrix(_mtx, N, M);
    }

    private static void SparseDemo()
    {
        Matrix.Sparse();
    }

    private static void UpperTriangular()
    {
        const int ARRAY_SIZE = 5;
        int[,] A = // 上三角矩陣
        {
            { 7, 8, 12, 21, 9 },
            { 0, 5, 14, 17, 6 },
            { 0, 0, 7, 23, 24 },
            { 0, 0, 0, 32, 19 },
            { 0, 0, 0, 0, 8 }
        };
        int[] B = new int[ARRAY_SIZE * (1 + ARRAY_SIZE) / 2];

        int GetValue(int i, int j)
        {
            int index = ARRAY_SIZE * i - i * (i + 1) / 2 + j;
            return B[index];
        }

        int i = 0,
            j = 0;
        int index;

        WriteLine("============================================");
        WriteLine("上三角形矩陣：");

        for (i = 0; i < ARRAY_SIZE; i++)
        {
            for (j = 0; j < ARRAY_SIZE; j++)
                Write("\t" + A[i, j]);
            WriteLine();
        }
        // 將右上三角矩陣壓縮為一維陣列
        index = 0;
        for (i = 0; i < ARRAY_SIZE; i++)
        {
            for (j = 0; j < ARRAY_SIZE; j++)
            {
                if (A[i, j] != 0)
                    B[index++] = A[i, j];
            }
        }

        WriteLine("============================================");
        WriteLine("以一維的方式表示：");
        Write("\t[");
        for (i = 0; i < ARRAY_SIZE; i++)
        {
            for (j = i; j < ARRAY_SIZE; j++)
                Write(" " + GetValue(i, j));
        }
        Write(" ]");
        WriteLine();
    }

    private static void LowerTriangular()
    {
        const int ARRAY_SIZE = 5; // 矩陣的維數大小
        int[,] A = // 下三角矩陣的內容
        {
            { 76, 0, 0, 0, 0 },
            { 54, 51, 0, 0, 0 },
            { 23, 8, 26, 0, 0 },
            { 43, 35, 28, 18, 0 },
            { 12, 9, 14, 35, 46 },
        };
        // 一維陣列宣告
        int[] B = new int[ARRAY_SIZE * (1 + ARRAY_SIZE) / 2];

        int GetValue(int i, int j)
        {
            int index = ARRAY_SIZE * i - i * (i + 1) / 2 + j;
            return B[index];
        }

        int i = 0,
            j = 0;
        int index;

        WriteLine("============================================");
        WriteLine("下三角形矩陣：");

        for (i = 0; i < ARRAY_SIZE; i++)
        {
            for (j = 0; j < ARRAY_SIZE; j++)
                Write($"\t{A[i, j]}");
            WriteLine();
        }

        // 將左下三角形壓縮成一維陣列
        index = 0;
        for (i = 0; i < ARRAY_SIZE; i++)
            for (j = 0; j < ARRAY_SIZE; j++)
                if (A[i, j] != 0)
                    B[index++] = A[i, j];

        WriteLine("============================================");
        WriteLine("以一維的方式表示：");
        Write("\t[");

        for (i = 0; i < ARRAY_SIZE; i++)
            for (j = 0; j < ARRAY_SIZE; j++)
                if (A[i, j] != 0)
                    Write($" {GetValue(i, j)}");

        Write(" ]");
    }
}
