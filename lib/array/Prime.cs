/// <summary>
/// 利用一維陣列尋找與儲存範圍 1 ~ MAX 內所有質數
/// 質數（prime number）是指不能被 1 和本身以外的數值所整除的整數
/// </summary>
class Prime
{
    public static void Execute()
    {
        const int MAX = 300;

        // false 為質數，true 為非質數
        // 宣告後若沒有給定初值，其預設值為 false
        bool[] prime = new bool[MAX];
        prime[0] = true; // 0 為非質數
        prime[1] = true; // 1 為非質數

        int num = 2,
            i;

        // 將 1 ~ MAX 中不是質數的，逐一過濾，以此方式找到所有質數
        while (num < MAX)
        {
            if (!prime[num])
            {
                for (i = num + num; i < MAX; i += num)
                {
                    if (prime[i])
                        continue;
                    prime[i] = true; // 設定為 true，代表此數非質數
                }
            }
            num++;
        }

        // 列印 1 ~ MAX 間所有質數
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
    }
}
