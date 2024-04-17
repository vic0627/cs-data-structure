namespace StackArray;

class Stack(int size)
{
    private readonly int[] stack = new int[size];
    private int top = -1;

    public bool Empty()
    {
        return top == -1;
    }

    public bool Push(int data)
    {
        if (top >= stack.Length)
            return false; // 堆疊已滿
        else
        {
            stack[++top] = data; // 存入堆疊
            return true;
        }
    }

    public int Pop()
    {
        if (Empty())
            return -1;
        else
            return stack[top--]; // 先取出資料，在下移堆疊指標
    }
}

class Program
{
    public static void Execute()
    {
        int value;
        Stack stack = new(10);
        WriteLine("請依序輸入 10 筆資料：");
        for (int i = 0; i < 10; i++)
        {
            value = int.Parse(ReadLine());
            stack.Push(value);
        }
        WriteLine("=======================");
        while (!stack.Empty())
            WriteLine("堆疊彈出的資料：" + stack.Pop());
    }
}
