using static System.Console;

delegate void Hooks<T>(params T[] value);

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

    /// <summary>
    /// 轉置矩陣
    /// </summary>
    /// <param name="arr">輸入矩陣</param>
    /// <returns>基於輸入矩陣的轉置矩陣</returns>
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

    public static int[,] CreateRandomSparse(int dimX = 10, int dimY = 10)
    {
        Random random = new();
        int[,] sparse = new int[dimX, dimY];
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

        TraverseMatrixOption option = new(arr);

        for (int row = 0; row < dimX; row++)
        {
            for (int col = 0; col < dimY; col++)
            {
                Write(arr[row, col] + " \t");
            }
            WriteLine();
        }
    }

    public static void TraverseMatrix(TraverseMatrixOption option)
    {
        for (int row = 0; row < option.DimX; row++)
        {
            option.onRowStart.Invoke(row);

            for (int col = 0; col < option.DimY; col++)
            {
                var value = option.target[row, col];
                option.onTarget.Invoke(value, row, col);
            }

            option.onRowEnd.Invoke(row);
        }
    }

    public class TraverseMatrixOption(int[,] target)
    {
        public readonly int[,] target = target;

        private int dimX = target.GetLength(0);
        private int dimY = target.GetLength(1);
        public int DimX
        {
            get => dimX;
            set
            {
                if (value < 1)
                {
                    WriteLine("輸入值不可小於 1");
                    return;
                }
                dimX = value;
            }
        }
        public int DimY
        {
            get => dimY;
            set
            {
                if (value < 1)
                {
                    WriteLine("輸入值不可小於 1");
                    return;
                }
                dimY = value;
            }
        }

        public Hooks<int> onRowStart = (int[] _) => { };
        public Hooks<int> onRowEnd = (int[] _) => { };
        public Hooks<int> onTarget = (int[] _) => { };
    }
}
