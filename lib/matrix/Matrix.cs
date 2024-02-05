using static System.Console;

class Matrix
{
    /// <summary>
    /// 矩陣相加
    /// </summary>
    /// <param name="arrA">輸入矩陣1</param>
    /// <param name="arrB">輸入矩陣2</param>
    /// <param name="arrC">輸出矩陣</param>
    /// <param name="dimX">行數</param>
    /// <param name="dimY">列數</param>
    public static void Add(int[,] arrA, int[,] arrB, int[,] arrC, int dimX = 3, int dimY = 3)
    {
        int row,
            col;
        if (dimX <= 0 || dimY <= 0)
        {
            WriteLine("矩陣維數必須大於零");
            return;
        }
        for (row = 0; row < dimX; row++)
        {
            for (col = 0; col < dimY; col++)
            {
                arrC[row, col] = arrA[row, col] + arrB[row, col];
            }
        }
    }

    /// <summary>
    /// 矩陣相乘
    /// </summary>
    /// <param name="arrA">輸入矩陣1</param>
    /// <param name="arrB">輸入矩陣2</param>
    /// <param name="arrC">輸出矩陣</param>
    /// <param name="M">arrA 行數</param>
    /// <param name="N">arrA 列數</param>
    /// <param name="P">arrB 列數</param>
    public static void Multiply(int[,]? arrA, int[,]? arrB, int[,] arrC, int M, int N, int P)
    {
        int i,
            j,
            k,
            Temp;
        if (M <= 0 || N <= 0 || P <= 0)
        {
            WriteLine("維度數 M，N，或 P 必須大於零");
            return;
        }

        if (arrA == null || arrB == null)
        {
            WriteLine("輸入陣列不得為 null");
            return;
        }

        for (i = 0; i < M; i++)
            for (j = 0; j < P; j++)
            {
                Temp = 0;
                for (k = 0; k < N; k++)
                    Temp += arrA[i, k] * arrB[k, j];
                arrC[i, j] = Temp;
            }
    }

    public static int[,] Transpose(int[,] arr)
    {
        int X = arr.GetLength(0);
        int Y = arr.GetLength(1);

        int[,] output = new int[Y, X];

        for (int x = 0; x < X; x++)
            for (int y = 0; y < Y; y++)
                output[y, x] = arr[x, y];

        return output;
    }

    /// <summary>
    /// 列印矩陣
    /// </summary>
    /// <param name="arr">目標矩陣</param>
    /// <param name="dimX">行數</param>
    /// <param name="dimY">列數</param>
    public static void PirntMatrix(int[,]? arr, int dimX = 3, int dimY = 3)
    {
        if (arr == null)
            return;

        for (int row = 0; row < dimX; row++)
        {
            for (int col = 0; col < dimY; col++)
            {
                Write(arr[row, col] + " \t");
            }
            WriteLine();
        }
    }
}
