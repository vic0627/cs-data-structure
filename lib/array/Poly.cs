namespace Poly;

class Program
{
    static readonly int ITEMS = 6;

    public static void Execute()
    {
        int[] PolyA = { 4, 3, 7, 0, 6, 2 }; // 宣告多項式 A
        int[] PolyB = { 4, 1, 5, 2, 0, 9 }; // 宣告多項式 B
        Write("A(x) = ");
        PrintPoly(PolyA, ITEMS); // 印出多項式 A
        Write("B(x) = ");
        PrintPoly(PolyB, ITEMS); // 印出多項式 B
        Write("A(x) + B(x) = ");
        PolySum(PolyA, PolyB); // 多項式 A + 多項式 B
    }

    static void PrintPoly(int[] Poly, int items)
    {
        int i,
            MaxExp;
        MaxExp = Poly[0];
        for (i = 1; i <= Poly[0] + 1; i++)
        {
            MaxExp--;
            if (Poly[i] != 0) // 該項式 0 就跳過
            {
                int _MaxExp = MaxExp + 1;
                if (_MaxExp == 1)
                {
                    Write(Poly[i] + "x");
                }
                else if (_MaxExp != 0)
                {
                    Write(Poly[i] + "x^" + _MaxExp);
                }
                else
                    Write(Poly[i]);
                if (MaxExp >= 0)
                    Write(" + ");
            }
        }
        WriteLine();
    }

    static void PolySum(int[] Poly1, int[] Poly2)
    {
        int i;
        int[] result = new int[ITEMS];
        result[0] = Poly1[0];
        for (i = 1; i <= Poly1[0] + 1; i++)
            result[i] = Poly1[i] + Poly2[i]; // 等冪的係數相加
        PrintPoly(result, ITEMS);
    }
}
