namespace Reverse;

class Node(int data, string names, int np)
{
    public int data = data;
    public int np = np;
    public string names = names;
    public Node next;
}

class StuLinkedList
{
    public Node first;
    public Node last;

    public bool IsEmpty()
    {
        return first == null;
    }

    public void Print()
    {
        Node current = first;
        while (current != null)
        {
            WriteLine($"[{current.data} {current.names} {current.np}]");
            current = current.next;
        }
        WriteLine();
    }

    public void Insert(int data, string names, int np)
    {
        Node newNode = new(data, names, np);
        if (IsEmpty())
        {
            first = newNode;
            last = newNode;
        }
        else
        {
            last.next = newNode;
            last = newNode;
        }
    }

    public void Delete(Node delNode)
    {
        Node newNode;
        Node tmp;
        if (first.data == delNode.data)
        {
            first = first.next;
        }
        else if (last.data == delNode.data)
        {
            newNode = first;
            while (newNode.next != last)
                newNode = newNode.next;
            newNode.next = last.next;
            last = newNode;
        }
        else
        {
            newNode = first;
            tmp = first;
            while (newNode.data != delNode.data)
            {
                tmp = newNode;
                newNode = newNode.next;
            }
            tmp.next = delNode.next;
        }
    }
}

class ReverseStuLinkedList : StuLinkedList
{
    public void ReversePrint()
    {
        Node current = first;
        Node before = null;
        WriteLine("反轉後的串列資料：");
        while (current != null)
        {
            last = before;
            before = current;
            current = current.next;
            before.next = last;
        }
        current = before;
        while (current != null)
        {
            WriteLine($"[{current.data} {current.names} {current.np}]");
            current = current.next;
        }
        WriteLine();
    }
}

class Program
{
    public static void Execute()
    {
        Random rand = new();
        ReverseStuLinkedList list = new();
        int i,
            j;
        const int ROW = 12;
        const int COL = 10;
        int[,] data = new int[ROW, COL];
        string[] name =
        {
            "Allen",
            "Scott",
            "Marry",
            "Jon",
            "Mark",
            "Ricky",
            "Lisa",
            "Jasica",
            "Hanson",
            "Amy",
            "Bob",
            "Jack"
        };
        WriteLine("座號成績座號成績座號成績座號成績座號成績\n");
        for (i = 0; i < ROW; i++)
        {
            data[i, 0] = i + 1;
            data[i, 1] = Math.Abs(rand.Next(50)) + 50;
            list.Insert(data[i, 0], name[i], data[i, 1]);
        }
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 4; j++)
            {
                int k = j * 3 + i;
                Write($"[{data[k, 0]}] [{data[k, 1]}] ");
            }
            WriteLine();
        }
        list.ReversePrint();
    }
}
