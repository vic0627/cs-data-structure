namespace Tower;

class Program
{
    public static void Execute()
    {
        int j;
        Write("please enter the amount of disks: ");
        j = int.Parse(ReadLine());
        Hanoi(j, 1, 2, 3);
    }

    private static void Hanoi(int n, int p1, int p2, int p3)
    {
        if (n == 1)
            WriteLine($"disk{n} move from stack{p1} to stack{p3}");
        else
        {
            Hanoi(n - 1, p1, p3, p2);
            WriteLine($"disk{n} move from stack{p1} to stack{p3}");
            Hanoi(n - 1, p2, p1, p3);
        }
    }
}
