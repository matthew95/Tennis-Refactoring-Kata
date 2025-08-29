namespace Tennis.TG3;

public class Helper
{
    public static string GetLeadName(Player player1, Player player2)
    {
        return player1.Score > player2.Score ? player1.Name : player2.Name;
    }
}