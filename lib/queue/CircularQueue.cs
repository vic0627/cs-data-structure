namespace CircularQueue;

class Program
{
    private const int MAX = 5;
    private static int front = -1,
        rear = -1,
        val;
    private static readonly int[] queue = new int[MAX];

    public static void Execute()
    {
        WriteLine("實作環狀佇列");
        WriteLine("==========================");
        bool loop = true;

        while (loop)
            loop = MainAction();
    }

    static bool MainAction()
    {
        switch (GetInput.GetInt("輸入[1]加入新數值進佇列，輸入[2]從佇列彈出數值，輸入[3]結束，請輸入："))
        {
            case 1:
                AddToQueue();
                PrintQueue();
                return true;
            case 2:
                DelFromQueue();
                return true;
            default:
                PrintQueue();
                return false;
        }
    }

    static void PrintQueue()
    {
        string msg = "當前佇列：";
        val = front;
        while (val != rear)
        {
            CircularIncrement(ref val);
            msg += $"[{queue[val]}]";
        }
        WriteLine(msg);
        WriteLine($"front: {front}, rear: {rear}");
    }

    static bool IsFull()
    {
        return rear + 1 == front || (rear == 4 && front <= 0);
    }

    static bool IsEmpty()
    {
        return front == rear;
    }

    static void AddToQueue()
    {
        if (IsFull())
        {
            WriteLine("佇列已滿，無法新增數值");
            return;
        }
        val = GetInput.GetInt("請輸入數值：");
        CircularIncrement(ref rear);
        queue[rear] = val;
    }

    static void DelFromQueue()
    {
        if (IsEmpty())
        {
            WriteLine("佇列已空，無法彈出數值");
            return;
        }
        CircularIncrement(ref front);
        val = queue[front];
        queue[front] = 0;
        WriteLine($"佇列彈出：[{val}]");
    }

    static void CircularIncrement(ref int x)
    {
        if (x < MAX - 1)
            x++;
        else
            x = 0;
    }
}
