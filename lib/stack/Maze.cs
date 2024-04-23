namespace Maze;

class Node(int x, int y)
{
    public int x = x;
    public int y = y;
    public Node next;
}

class TraceRecord
{
    public Node first;
    public Node last;

    public bool IsEmpty()
    {
        return first == null;
    }

    public void Insert(int x, int y)
    {
        Node newNode = new(x, y);
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

    public void Delete()
    {
        Node newNode;
        if (IsEmpty())
        {
            Write("堆疊已經空了");
            return;
        }
        newNode = first;
        while (newNode.next != last)
            newNode = newNode.next;
        newNode.next = last.next;
        last = newNode;
    }
}

class Program
{
    private static readonly int ExitX = 8; // 定義出口的 x 座標
    private static readonly int ExitY = 10; // 定義出口的 y 座標
    private static readonly int[,] MAZE =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
        { 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1 },
        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    };

    private static int ChkExit(int x, int y, int ex, int ey)
    {
        if (x == ex && y == ey)
        {
            int north = MAZE[x - 1, y];
            int south = MAZE[x + 1, y];
            int east = MAZE[x, y + 1];
            int west = MAZE[x, y - 1];
            bool caseA = north == 1 || south == 1 || west == 1 || east == 2;
            bool caseB = north == 1 || south == 1 || west == 2 || east == 1;
            bool caseC = north == 1 || south == 2 || west == 1 || east == 1;
            bool caseD = north == 2 || south == 1 || west == 1 || east == 1;
            if (caseA || caseB || caseC || caseD)
                return 1;
        }
        return 0;
    }

    public static void Execute()
    {
        int i,
            j,
            x = 1,
            y = 1;
        TraceRecord path = new();
        WriteLine("[迷宮路徑(0的部分)]：");
        for (i = 0; i < 10; i++)
        {
            for (j = 0; j < 12; j++)
                Write(MAZE[i, j]);
            Write("\n");
        }
        while (x <= ExitX && y <= ExitY)
        {
            MAZE[x, y] = 2;
            if (MAZE[x - 1, y] == 0)
            {
                x -= 1;
                path.Insert(x, y);
            }
            else if (MAZE[x + 1, y] == 0)
            {
                x += 1;
                path.Insert(x, y);
            }
            else if (MAZE[x, y - 1] == 0)
            {
                y -= 1;
                path.Insert(x, y);
            }
            else if (MAZE[x, y + 1] == 0)
            {
                y += 1;
                path.Insert(x, y);
            }
            else if (ChkExit(x, y, ExitX, ExitY) == 1)
                break;
            else
            {
                MAZE[x, y] = 2;
                path.Delete();
                x = path.last.x;
                y = path.last.y;
            }
        }
        WriteLine("[老鼠走過的路徑(2的部分)]：");
        for (i = 0; i < 10; i++)
        {
            for (j = 0; j < 12; j++)
                Write(MAZE[i, j]);
            WriteLine();
        }
    }
}
