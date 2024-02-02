using static System.Console;
/// <summary>
/// 利用二維陣列來儲存產生的亂數。
/// 亂數產生時需檢查號碼是否重複，利用二維陣列的索引質特性及 while 迴圈機制做反向檢查，完成 6 個不會重複的號碼。
/// </summary>
class TwoDim
{
    public static void Execute()
    {
        // 產生亂數次數
        int intCreate = 1000000;
        // 產生的亂數號碼
        Random Rand = new();
        // 置放亂數的陣列
        int[][] intArray = [new int[42], new int[42]];
        // 將產生的亂數存放至陣列
        int intRand;
        while (intCreate-- > 0)
        {
            intRand = Rand.Next(42);
            intArray[0][intRand]++;
            intArray[1][intRand]++;
        }
        // 對 intArray[0] 陣列做排序
        Array.Sort(intArray[0]);
        // 找出最大數六個數字號碼
        for (int i = 41; i > (41 - 6); i--)
        {
            // 逐一檢查次數相同者
            for (int j = 41; j >= 0; j--)
            {
                // 當次數符合時印出
                if (intArray[0][i] == intArray[1][j])
                {
                    WriteLine($"亂數號碼 {j + i} 出現 {intArray[0][i]} 次");
                    // 將找到的數值次數歸零
                    intArray[1][j] = 0;
                    break;
                }
            }
        }
    }
}
