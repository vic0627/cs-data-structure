namespace Insert;

class Node(int data)
{
    public int data = data;
    public Node next = null;
}

class LinkedList
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
            Write($"[{current.data}]");
            current = current.next;
        }
        WriteLine();
    }

    /// <summary>
    /// 串接兩個鏈結串列
    /// </summary>
    /// <param name="head1">串列一</param>
    /// <param name="head2">串列二</param>
    /// <returns>串列一</returns>
    public static LinkedList Concatenate(LinkedList head1, LinkedList head2)
    {
        LinkedList ptr = head1;
        while (ptr.last.next != null)
        {
            ptr.last = ptr.last.next;
            Write("loop...\t");
        }
        ptr.last.next = head2.first;
        return head1;
    }

    public void Insert(Node ptr)
    {
        Node tmp;
        Node newNode;
        if (IsEmpty())
        {
            first = ptr;
            last = ptr;
        }
        else
        {
            if (ptr.next == first)
            {
                ptr.next = first;
                first = ptr;
            }
            else
            {
                if (ptr.next == null)
                {
                    last.next = ptr;
                    last = ptr;
                }
                else
                {
                    newNode = first;
                    tmp = first;
                    while (ptr.next != newNode.next)
                    {
                        tmp = newNode;
                        newNode = newNode.next;
                    }
                    tmp.next = ptr;
                    ptr.next = newNode;
                }
            }
        }
    }
}

class Client
{
    public static void Execute()
    {
        LinkedList list1 = new();
        LinkedList list2 = new();
        Node node1 = new(5);
        Node node2 = new(6);
        list1.Insert(node1);
        list1.Insert(node2);
        Node node3 = new(7);
        Node node4 = new(8);
        list2.Insert(node3);
        list2.Insert(node4);
        LinkedList.Concatenate(list1, list2);
        list1.Print();
    }
}
