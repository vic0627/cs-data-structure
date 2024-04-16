using System.Reflection.Metadata;

namespace Circular;

class Node(int data, string names, int np)
{
    public int data = data;
    public string names = names;
    public int np = np;
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
            newNode = newNode.next;
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

class ConcatStuLinkedList : StuLinkedList
{
    public StuLinkedList Concat(StuLinkedList stuList)
    {
        last.next = stuList.first;
        last = stuList.last;
        return this;
    }
}

class Program
{
    public static void Execute()
    {
        ConcatStuLinkedList list1 = new();
        StuLinkedList list2 = new();
        int[,] data = new int[12, 10];
        string[] name1 =
        {
            "Liam",
            "Olivia",
            "Noah",
            "Emma",
            "Elijah",
            "Ava",
            "William",
            "Sophia",
        };
        string[] name2 =
        {
            "James",
            "Isabella",
            "Benjamin",
            "Mia",
            "Lucas",
            "Harper",
            "Henry",
            "Charlotte",
        };
        WriteLine("座號 成績 座號 成績 座號 成績 座號 成績\n");
        InsertRandData(name1, data, list1);
        PrintData(data);
        InsertRandData(name2, data, list2);
        PrintData(data);
        list1.Concat(list2);
        list1.Print();
    }

    private static void InsertRandData(string[] names, int[,] data, StuLinkedList list)
    {
        Random rand = new();
        for (int i = 0; i < names.Length; i++)
        {
            data[i, 0] = i + 1;
            data[i, 1] = Math.Abs(rand.Next(50)) + 50;
            list.Insert(data[i, 0], names[i], data[i, 1]);
        }
    }

    private static void PrintData(int[,] data)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
                Write($"[{data[j + i * 4, 0]}] [{data[j + i * 4, 1]}] ");
            WriteLine();
        }
    }
}
