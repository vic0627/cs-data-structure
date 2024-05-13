namespace In2Post;

class Program
{
    static readonly int MAX = 50;
    static char[] infixQ = new char[MAX];

    public static int Compare(char stackO, char infixO)
    {
        char[] infixPriority = new char[9];
        char[] stackPriority = new char[8];
        int indexS = 0,
            indexI = 0;

        infixPriority[0] = 'q';
        infixPriority[1] = ')';
        infixPriority[2] = '+';
        infixPriority[3] = '-';
        infixPriority[4] = '*';
        infixPriority[5] = '/';
        infixPriority[6] = '^';
        infixPriority[7] = ' ';
        infixPriority[8] = '(';

        stackPriority[0] = 'q';
        stackPriority[1] = '(';
        stackPriority[2] = '+';
        stackPriority[3] = '-';
        stackPriority[4] = '*';
        stackPriority[5] = '/';
        stackPriority[6] = '^';
        stackPriority[7] = ' ';

        while (stackPriority[indexS] != stackO)
            indexS++;
        while (infixPriority[indexI] != infixO)
            indexI++;

        return indexS / 2 >= indexI / 2 ? 1 : 0;
    }

    public static void InfixToPostfix()
    {
        int rear = 0,
            top = 0,
            flag = 0,
            i = 0;
        char[] stackT = new char[MAX];

        for (i = 0; i < MAX; i++)
            stackT[i] = '\0';

        while (infixQ[rear] != '\n')
        {
            try
            {
                infixQ[++rear] = (char)Read();
            }
            catch (IOException e)
            {
                WriteLine(e);
            }
        }

        infixQ[rear - 1] = 'q';
        Write("後序表示法：");
        stackT[top] = 'q';
        for (flag = 0; flag <= rear; flag++)
        {
            switch (infixQ[flag])
            {
                case ')':
                    while (stackT[top] != '(')
                        Write(stackT[top--]);
                    top--;
                    break;
                case 'q':
                    while (stackT[top] != 'q')
                        Write(stackT[top--]);
                    break;
                case '(':
                case '^':
                case '*':
                case '/':
                case '+':
                case '-':
                    while (Compare(stackT[top], infixQ[flag]) == 1)
                        Write(stackT[top--]);
                    stackT[++top] = infixQ[flag];
                    break;
                default:
                    Write(infixQ[flag]);
                    break;
            }
        }
    }

    public static void Execute()
    {
        int i = 0;
        for (i = 0; i < MAX; i++)
            infixQ[i] = '\0';

        Write("=========================================\n");
        Write("本程式會將其轉成後序運算式\n");
        Write("請輸入中序運算式\n");
        Write("例如：(9+3)*8+7*6-12/4\n");
        Write("可以使用的運算子包括：^、+、-、*、/、() ...等\n");
        Write("=========================================\n");
        Write("請開始輸入中序運算式：\n");

        InfixToPostfix();
        Write("=========================================\n");
    }
}
