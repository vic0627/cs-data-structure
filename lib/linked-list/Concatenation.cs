namespace Concatenation;

class Node(int coef, int exp)
{
    public int coef = coef;
    public int exp = exp;
    public Node next;
}

class PolyLinkedList
{
    public Node first;
    public Node last;

    public bool IsEmpty()
    {
        return first == null;
    }

    public void CreateLink(int coef, int exp)
    {
        Node newNode = new(coef, exp);
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

    public void PrintLink()
    {
        Node current = first;
        while (current != null)
        {
            if (current.exp == 1 && current.coef != 0) // x^1 時不顯示指數
                Write(current.coef + "X + ");
            else if (current.exp != 0 && current.coef != 0)
                Write(current.coef + "X^" + current.exp + " + ");
            else if (current.coef != 0) // x^0 時不顯示變數
                Write(current.coef);
            current = current.next;
        }
        WriteLine();
    }

    public PolyLinkedList SumLink(PolyLinkedList b)
    {
        int[] sum = new int[10];
        int i = 0,
            maxNumber;
        PolyLinkedList tmpList = new();
        PolyLinkedList a = this;
        int[] tmpExp = new int[10];
        Node ptr = b.first;
        while (a.first != null) // 判斷多項式 1
        {
            b.first = ptr; // 重複比較 A 及 B 的指數
            while (b.first != null)
            {
                if (a.first.exp == b.first.exp) // 指數相等，係數相加
                {
                    sum[i] = a.first.coef + b.first.coef;
                    tmpExp[i] = a.first.exp;
                    a.first = a.first.next;
                    b.first = b.first.next;
                    i++;
                }
                else if (b.first.exp > a.first.exp) // B 指數較大，指定係數給 C
                {
                    sum[i] = b.first.coef;
                    tmpExp[i] = b.first.exp;
                    b.first = b.first.next;
                    i++;
                }
                else if (a.first.exp > b.first.exp) // A 指數較大，指定係數給 C
                {
                    sum[i] = a.first.coef;
                    tmpExp[i] = a.first.exp;
                    a.first = a.first.next;
                    i++;
                }
            } // end of inner while loop
        } // end of outer while loop
        maxNumber = i - 1;
        for (int j = 0; j < maxNumber + 1; j++)
            tmpList.CreateLink(sum[j], maxNumber - j);
        return tmpList;
    }
}

class Program
{
    public static void Execute()
    {
        PolyLinkedList a = new();
        PolyLinkedList b = new();
        PolyLinkedList c;
        int[] data1 = { 8, 54, 7, 0, 1, 3, 0, 4, 2 }; // 多項式 A 的係數
        int[] data2 = { -2, 6, 0, 0, 0, 5, 6, 8, 6, 9 }; // 多項式 B 的係數
        for (int i = 0; i < data1.Length; i++)
            a.CreateLink(data1[i], data1.Length - i - 1); // 建立多項式 A，係數由 3 遞減
        for (int i = 0; i < data2.Length; i++)
            b.CreateLink(data2[i], data2.Length - i - 1); // 建立多項式 B，係數由 3 遞減
        Write("原始多項式：\nA = ");
        a.PrintLink(); // 列印多項式 A
        Write("B = ");
        b.PrintLink(); // 列印多項式 B
        Write("多項式相加結果：\nC = ");
        c = a.SumLink(b);
        c.PrintLink(); // 列印多項式 C
    }
}
