using static System.Console;

static class Factorial
{
    public static void Execute()
    {
        WriteLine($"5!={Fac(5)}");
        ReadKey();
    }

    static int Fac(int n)
    {
        if (n == 0) // 遞迴終止的條件
            return 1;
        else
            return n * Fac(n - 1); // 遞迴呼叫
    }
}
