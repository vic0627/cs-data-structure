namespace Single;

internal class Node(int data, string names, int np)
{
    public int data = data;
    public string names = names;
    public int np = np;
    public Node next;
}

internal class LinkedList
{
    private Node first;
    private Node last;

    /// <summary>
    /// 判斷目前串列是否為空
    /// </summary>
    /// <returns>是空串列</returns>
    public bool IsEmpty()
    {
        return first == null;
    }

    /// <summary>
    /// 將目前串列內容印出來
    /// </summary>
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

    /// <summary>
    /// 在當前串列尾插入一個新的節點
    /// </summary>
    /// <param name="data">資料</param>
    /// <param name="names">學生姓名</param>
    /// <param name="np">學生座號</param>
    /// <exception cref="Exception">插入失敗</exception>
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
            throw new Exception("插入節點失敗！");
    }
}

class Program
{
    public static void Execute()
    {
        int num;
        string name;
        int score;

        WriteLine("請輸入 5 筆學生資料：");
        LinkedList list = new();
        for (int i = 0; i < 6; i++)
        {
            Write("請輸入座號：");
            num = int.Parse(GetReadLine());
            Write("請輸入姓名：");
            name = GetReadLine();
            Write("請輸入成績：");
            score = int.Parse(GetReadLine());
            list.Insert(num, name, score);
            WriteLine("==============================");
        }
        WriteLine("學 生 成 績");
        WriteLine("座號  姓名  成績  ============");
        list.Print();
    }

    public static string GetReadLine()
    {
        return ReadLine() ?? "";
    }
}
