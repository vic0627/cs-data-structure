class Iterative
{
    public static void Execute()
    {
        int sum = 1;

        Write("請從鍵盤輸入n= ");
        int n = int.Parse(ReadLine() ?? "0");

        // 以 for 迴圈計算 n!
        for (int i = 1; i < n + 1; i++)
        {
            for (int j = i; j > 0; j--)
                sum *= j;
            WriteLine(i + "!=" + sum);
            sum = 1;
        }

        ReadKey();
    }
}
