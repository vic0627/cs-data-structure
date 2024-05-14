class GetInput
{
    public static string GetString(string inputMessage = "")
    {
        if (inputMessage != null || inputMessage != "")
            WriteLine(inputMessage);
        return ReadLine();
    }

    public static int GetInt(string inputMessage = "")
    {
        return int.Parse(GetString(inputMessage));
    }
}
