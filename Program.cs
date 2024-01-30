using static System.Console;

const int MAX = 300;

bool[] prime = new bool[MAX];
prime[0] = true;
prime[1] = true;

int num = 2, i;

while (num < MAX)
{
    if (!prime[num])
    {
        for (i = num + num; i < MAX; i += num)
        {
            if (prime[i]) continue;
            prime[i] = true;
        }
    }
    num++;
}


WriteLine($"1 到 {MAX} 間的所有質數：");

for (i = 2, num = 0; i < MAX; i++)
{
    if (!prime[i])
    {
        Write(i + "\t");
        num++;
    }
}

WriteLine("\n質數總數 = " + num + " 個");

ReadKey();