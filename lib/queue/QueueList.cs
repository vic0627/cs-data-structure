namespace QueueList;

class QueueNode(int data)
{
    public int data = data;
    public QueueNode next;
}

class LinkedListQueue
{
    public QueueNode front;
    public QueueNode rear;

    public bool Enqueue(int value)
    {
        QueueNode node = new(value);
        if (rear == null)
            front = node;
        else
            rear.next = node;
        rear = node;
        return true;
    }

    public int Dequeue()
    {
        int value;
        if (!(front == null))
        {
            if (front == rear)
                rear = null;
            value = front.data;
            front = front.next;
            return value;
        }
        else
            return -1;
    }

    public void Print()
    {
        QueueNode tmp = front;
        Write("[當前佇列]：");
        while (tmp != null)
        {
            Write($"[{tmp.data}]");
            tmp = tmp.next;
        }
        WriteLine("");
    }
}

class Program
{
    static LinkedListQueue queue;

    public static void Execute()
    {
        WriteLine("[串列實作佇列]");
        WriteLine("=============================");
        queue = new();
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
                return true;
            case 2:
                DelFromQueue();
                return true;
            default:
                queue.Print();
                return false;
        }
    }

    static void AddToQueue()
    {
        queue.Enqueue(GetInput.GetInt("[請輸入數值]："));
        queue.Print();
    }

    static void DelFromQueue()
    {
        int val = queue.Dequeue();
        if (val == -1)
            WriteLine("[佇列已經空了]");
        else
            WriteLine($"[彈出元素]：[{val}]");
    }
}
