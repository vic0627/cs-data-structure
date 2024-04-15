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
    public static void Multiply(int[,] arrA, int[,] arrB, int[,] arrC, int M, int N, int P)
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

    /// <summary>
    /// 利用三項式（3-tuple）資料結構，壓縮 8 * 8 稀疏矩陣
    /// </summary>
    public static void Sparse()
    {
        const int _ROWS = 8; // 定義列數
        const int _COLS = 9; // 定義行數
        const int _NOTZERO = 8; // 定義稀疏矩陣中不為 0 的個數
        int i,
            j,
            tmpRW,
            tmpCL,
            tmpNZ;
        int temp = 1;
        int[,] Sparse = new int[_ROWS, _COLS]; // 宣告稀疏矩陣
        int[,] Compress = new int[_NOTZERO + 1, 3]; // 宣告壓縮矩陣
        Random intRand = new(); // 宣告 Random 物件
        for (i = 0; i < _ROWS; i++) // 將稀疏矩陣中所有元素設為 0
            for (j = 0; j < _COLS; j++)
                Sparse[i, j] = 0;
        tmpNZ = _NOTZERO;
        for (i = 1; i < tmpNZ + 1; i++)
        {
            tmpRW = intRand.Next(100);
            tmpRW %= _ROWS;
            tmpCL = intRand.Next(100);
            tmpCL %= _COLS;
            if (Sparse[tmpRW, tmpCL] != 0) // 避免同一個元素設定兩次數值而造成壓縮矩陣
                tmpNZ++;
            Sparse[tmpRW, tmpCL] = i;
        }
        WriteLine("[稀疏矩陣的各個元素]"); // 印出稀疏矩陣的各個元素
        for (i = 0; i < _ROWS; i++)
        {
            for (j = 0; j < _COLS; j++)
                Write(Sparse[i, j] + " ");
            WriteLine();
        }
        // 開始壓縮稀疏矩陣
        Compress[0, 0] = _ROWS;
        Compress[0, 1] = _COLS;
        Compress[0, 2] = _NOTZERO;
        for (i = 0; i < _ROWS; i++)
            for (j = 0; j < _COLS; j++)
                if (Sparse[i, j] != 0)
                {
                    Compress[temp, 0] = i;
                    Compress[temp, 1] = j;
                    Compress[temp, 2] = Sparse[i, j];
                    temp++;
                }
        WriteLine("[稀疏矩陣壓縮後的內容]"); // 印出壓縮矩陣的各個元素
        for (i = 0; i < _NOTZERO; i++)
        {
            for (j = 0; j < 3; j++)
                Write(Compress[i, j] + " ");
            WriteLine();
        }
    }

    /// <summary>
    /// 列印矩陣
    /// </summary>
    /// <param name="arr">目標矩陣</param>
    /// <param name="dimX">行數</param>
    /// <param name="dimY">列數</param>
    public static void PirntMatrix(int[,] arr, int dimX = 3, int dimY = 3)
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
