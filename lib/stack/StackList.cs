namespace StackList;

class Node(int data)
{
    public int data = data;
    public Node next;
}

class Stack
{
    public Node front;
    public Node rear;

    public bool IsEmpty()
    {
        return front == null;
    }

    public void Print()
    {
        Node current = front;
        while (current != null)
        {
            Write($"{current.data}\t");
            current = current.next;
        }
        WriteLine();
    }

    public void Insert(int data)
    {
        Node newNode = new(data);
        if (IsEmpty())
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.next = newNode;
            rear = newNode;
        }
    }

    public void Pop()
    {
        Node newNode;
        if (IsEmpty())
        {
            Write("===目前為空堆疊===\n");
            return;
        }
        newNode = front;
        if (newNode == rear)
        {
            front = null;
            rear = null;
        }
        else
        {
            while (newNode.next != rear)
                newNode = newNode.next;
            newNode.next = rear.next;
            rear = newNode;
        }
    }
}

class Program
{
    public static void Execute()
    {
        Stack stack = new();
        int choice;
        while (true)
        {
            Write("(0)結束(1)在堆疊加入資料(2)彈出堆疊資料：");
            choice = int.Parse(ReadLine());
            if (choice == 2)
            {
                stack.Pop();
                WriteLine("資料彈出堆疊內容：");
                stack.Print();
            }
            else if (choice == 1)
            {
                Write("請輸入要加入堆疊的資料：");
                choice = int.Parse(ReadLine());
                stack.Insert(choice);
                WriteLine("資料加入堆疊內容：");
                stack.Print();
            }
            else if (choice == 0)
                break;
            else
                WriteLine("輸入錯誤！");
        }
    }
}
