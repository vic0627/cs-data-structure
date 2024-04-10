using static System.Console;

namespace Score;

internal class Node(int data, string names, int np)
{
    public int data = data;
    public string names = names;
    public int np = np;
    public Node? next;

    internal void Deconstruct(out int data, out string names, out int np)
    {
        data = this.data;
        names = this.names;
        np = this.np;
    }
}

internal class StuLinkedList
{
    public Node? first;
    public Node? last;

    public bool IsEmpty()
    {
        return first == null;
    }

    public Node? GetNodeByData(int data)
    {
        if (IsEmpty())
            return null;

        Node? current = first;

        while (current != null)
        {
            if (current?.data == data)
                return current;
            current = current?.next;
        }

        return null;
    }

    public void Print()
    {
        Node? current = first;
        while (current != null)
        {
            var (data, names, np) = current;
            WriteLine($"[ {data} {names} {np} ]");
            current = current.next;
        }
    }

    public void Insert(int data, string names, int np)
    {
        Node newNode = new(data, names, np);
        if (IsEmpty())
        {
            first = newNode;
            last = newNode;
        }
        else if (last != null)
        {
            last.next = newNode;
            last = newNode;
        }
        else
            throw new NotImplementedException();
    }

    public void Delete(Node delNode)
    {
        Node? newNode;
        Node? tmp;

        if (first?.data == delNode.data)
            first = first.next;
        else if (last?.data == delNode.data)
        {
            newNode = first;
            while (newNode?.next != last)
                newNode = newNode?.next;
            newNode.next = last.next;
            last = newNode;
        }
        else
        {
            newNode = first;
            tmp = first;
            while (newNode?.data != delNode.data)
            {
                tmp = newNode;
                newNode = newNode?.next;
            }
            if (tmp != null)
                tmp.next = delNode.next;
        }
    }
}

class Program
{
    public static void Main()
    {
        Random rand = new();
        StuLinkedList list = new();
        int i,
            j,
            findword;
        int[,] data = new int[12, 10];
        string[] name =
        {
            "Allen",
            "Scott",
            "Marry",
            "Jon",
            "Mark",
            "Ricky",
            "Lisa",
            "Jessica",
            "Hanson",
            "Amy",
            "Bob",
            "Jack"
        };

        WriteLine("座號成績座號成績座號成績座號成績\n");

        for (i = 0; i < 12; i++)
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

        while (true)
        {
            Write("請輸入要刪除成績的座號，結束請輸入 -1： ");
            findword = int.Parse(ReadLine() ?? "");
            if (findword == -1)
                break;
            else
            {
                Node? current = list?.GetNodeByData(findword);
                if (current != null)
                    list?.Delete(current);
                else
                {
                    WriteLine("找不到刪除對象！");
                    continue;
                }
            }

            WriteLine("刪除後成績串列，請注意！要刪除的成績其座號必須在此串列中\n");

            list?.Print();
        }
    }
}
