namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private class Player
        {
            public int Score { get; set; }
            public string Name { get; set; }
        }
        
        private readonly Player _player1;
        private readonly Player _player2;
        
        public TennisGame3(string player1Name, string player2Name)
        {
            this._player1 = new Player() { Name = player1Name };
            this._player2 = new Player() { Name = player2Name };
        }

        private bool diffeq(int p1, int p2, int to)
        {
            return (p1 - p2) == to || (p2 - p1) == to;
        }
        public string GetScore()
        {
            if ((_player1.Score >= 3 || _player2.Score >= 3) && _player1.Score == _player2.Score)
                return "Deuce";
            
            if ((_player1.Score > 3 || _player2.Score > 3) && _player1.Score != _player2.Score)
            {
                var lead = _player1.Score > _player2.Score ? _player1.Name : _player2.Name;
                return diffeq(_player1.Score, _player2.Score, 1) ? "Advantage " + lead : "Win for " + lead;
            }
            
            string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
            return (_player1.Score == _player2.Score) ? p[_player1.Score] + "-All" : p[_player1.Score] + "-" + p[_player2.Score];
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
                _player1.Score += 1;
            else if (playerName == _player2.Name)
                _player2.Score += 1;
        }

    }
}