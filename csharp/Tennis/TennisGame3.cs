namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private class Player
        {
            public int Score { get; set; }
            public string Name { get; set; }
        }
        
        private Player player1;
        private Player player2;
        
        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1 = new Player() { Name = player1Name };
            this.player2 = new Player() { Name = player2Name };
        }

        public string GetScore()
        {
            string s;
            if ((player1.Score < 4 && player2.Score < 4) && (player1.Score + player2.Score < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[player1.Score];
                return (player1.Score == player2.Score) ? s + "-All" : s + "-" + p[player2.Score];
            }
            else
            {
                if (player1.Score == player2.Score)
                    return "Deuce";
                s = player1.Score > player2.Score ? player1.Name : player2.Name;
                return ((player1.Score - player2.Score) * (player1.Score - player2.Score) == 1) ? "Advantage " + s : "Win for " + s;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1.Name)
                this.player1.Score += 1;
            else if (playerName == player2.Name)
                this.player2.Score += 1;
        }

    }
}