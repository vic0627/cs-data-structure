/// <summary>
/// 利用三層巢狀迴圈找出 2 x 3 x 3 陣列中所储存的數值中的最小值。
/// </summary>
class ThreeDim
{
    public static void Execute()
    {
        int[,,] num =
        {
            {
                { 33, 45, 67 },
                { 23, 71, 56 },
                { 55, 38, 66 }
            },
            {
                { 21, 9, 15 },
                { 38, 69, 18 },
                { 90, 101, 89 }
            }
        };

        int min = num[0, 0, 0];

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 3; j++)
                for (int k = 0; k < 3; k++)
                    if (min >= num[i, j, k])
                        min = num[i, j, k];

        Write("最小值= " + min + "\n");
        ReadKey();
    }
}
