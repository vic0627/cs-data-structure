namespace Shuffle;

class Program
{
    static int top = -1;

    public static void Execute()
    {
        int[] card = new int[52];
        int[] stack = new int[52];
        int i,
            j,
            k = 0,
            test;
        char ascVal;
        int style;
        Random intRand = new();
        for (i = 0; i < 52; i++)
            card[i] = i;
        WriteLine("[洗牌中... 請稍後！]");
        while (k < 30)
        {
            for (i = 0; i < 51; i++)
            {
                for (j = i + 1; j < 52; j++)
                {
                    if ((intRand.Next(10000) % 52) == 2)
                    {
                        test = card[i]; // 洗牌
                        card[i] = card[j];
                        card[j] = test;
                    }
                }
            }
            k++;
        }
        i = 0;
        while (i != 52)
        {
            Push(stack, 52, card[i]);
            i++;
        }
        WriteLine("[逆時針發牌]\n[顯示各家牌子]\n東家\t北家\t西家\t南家");
        WriteLine("============================");
        while (top >= 0)
        {
            style = stack[top] / 13; // 計算牌子花色
            ascVal = style switch
            {
                0 => '\u2660',
                1 => '\u2665',
                2 => '\u2666',
                3 => '\u2663',
                _ => throw new ArgumentOutOfRangeException()
            };
            Write($"[{ascVal}{stack[top] % 13 + 1}]");
            Write("\t");
            if (top % 4 == 0)
                WriteLine();
            top--;
        }
    }

    public static void Push(int[] stack, int max, int val)
    {
        if (top >= max - 1)
            return;
        else
        {
            top++;
            stack[top] = val;
        }
    }

    public static int Pop(int[] stack)
    {
        if (top < 0)
            return -1;
        top--;
        return stack[top];
    }
}
