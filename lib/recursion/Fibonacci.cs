using static System.Console;

delegate int IntDelegate(int n);

class Fibonacci
{
    public static void Execute()
    {
        int num;
        string str;
        string? strategyName = null;
        IntDelegate? intDelegate = null;

        WriteLine("請選擇一般遞迴或動態規劃法計算費式級數");
        Write("請輸入算法（0: 一般遞迴、1: 動態規劃法）：");

        str = ReadLine() ?? "0";

        if (str == "0")
        {
            intDelegate = new IntDelegate(Fib);
            strategyName = "一般遞迴";
        }
        else if (str == "1")
        {
            intDelegate = new IntDelegate(FibDPA);
            strategyName = "動態規劃法";
        }

        if (intDelegate != null && strategyName != null)
        {
            WriteLine($"使用{strategyName}計算費式級數");
            Write("請輸入一個整數：");

            str = ReadLine() ?? "0";
            num = int.Parse(str);

            if (num < 0)
                WriteLine("輸入數字必須大於 0");
            else
                Write("Fibonacci(" + num + ")=" + intDelegate(num) + "\n");
        }
        else
            WriteLine("查無相關算法！");

        ReadKey();
    }

    static int Fib(int n)
    {
        if (n == 0) // 第 0 項為 0
            return 0;
        else if (n == 1) // 第 1 項為 1
            return 1;
        else
            return Fib(n - 1) + Fib(n - 2); // 遞迴呼叫函數第 n 項為 n-1 跟 n-2 之和
    }

    static readonly int[] tempInt = new int[1000];

    static int FibDPA(int n)
    {
        int res;
        res = tempInt[n];

        if (res == 0)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
                return FibDPA(n - 1) + FibDPA(n - 2);
        }

        tempInt[n] = res;
        return res;
    }
}
