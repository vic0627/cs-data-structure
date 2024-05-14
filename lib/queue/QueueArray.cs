namespace QueueArray;

class Program
{
    public static int front = -1,
        rear = -1,
        max = 20;
    public static int val;
    public static int[] queue = new int[max];

    public static void Execute()
    {
        string strM;
        int m = 0;
        while (rear < max - 1 && m != 3)
        {
            Write("[1]存入一個數值[2]取出一個數值[3]結束：");
            strM = ReadLine();
            m = int.Parse(strM);

            switch (m)
            {
                case 1:
                    WriteLine("[請輸入數值]：");
                    strM = ReadLine();
                    val = int.Parse(strM);
                    rear++;
                    queue[rear] = val;
                    break;
                case 2:
                    if (rear > front)
                    {
                        front++;
                        WriteLine($"[取出數值為]：[{queue[front]}]");
                        queue[front] = 0;
                    }
                    else
                    {
                        WriteLine("[佇列已經空了]");
                        break;
                    }
                    break;
                default:
                    WriteLine("");
                    break;
            }
        }

        if (rear == max - 1)
            WriteLine("[佇列已經滿了]");
        Write("\n[目前佇列中的資料]：");
        if (front >= rear)
        {
            Write("沒有\n");
            WriteLine("[佇列已經空了]");
        }
        else
        {
            while (rear > front)
            {
                front++;
                Write($"[{queue[front]}]");
            }
            WriteLine("");
        }
    }
}
