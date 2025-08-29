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
        
        private static string GetLeadName(Player player1, Player player2)
        {
            return player1.Score > player2.Score ? player1.Name : player2.Name;
        }

        private interface IState
        {
            public string GetScore(TennisGame3 game);
            public IState WonPoint(TennisGame3 game);
        }

        private IState _state = new Start();
        private class Start : IState
        {
            public string GetScore(TennisGame3 game)
            {
                string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
                return (game._player1.Score == game._player2.Score) ? p[game._player1.Score] + "-All" : p[game._player1.Score] + "-" + p[game._player2.Score];
            }

            public IState WonPoint(TennisGame3 game)
            {
                if ((game._player1.Score >= 3 || game._player2.Score >= 3) && game._player1.Score == game._player2.Score)
                {
                    return new Deuce();
                }

                if (game._player1.Score == 4 || game._player2.Score == 4)
                {
                    return new Won();
                }
                
                return this;
            }
        }
        
        private class Deuce : IState
        {
            public string GetScore(TennisGame3 game)
            {
                return "Deuce";
            }

            public IState WonPoint(TennisGame3 game)
            {
                return new Advantage();
            }
        }

        private class Advantage : IState
        {
            public string GetScore(TennisGame3 game)
            {
                return "Advantage " + GetLeadName(game._player1, game._player2);
            }

            public IState WonPoint(TennisGame3 game)
            {
                if (game._player1.Score == game._player2.Score)
                {
                    return new Deuce();
                }

                return new Won();
            }
        }

        private class Won : IState
        {
            public string GetScore(TennisGame3 game)
            {
                return "Win for " + GetLeadName(game._player1, game._player2);
            }

            public IState WonPoint(TennisGame3 game)
            {
                return this;
            }
        }
        

        public string GetScore()
        {
            return _state.GetScore(this);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
            {
                _player1.Score += 1;
            }

            if (playerName == _player2.Name)
            {
                _player2.Score += 1;
            }
            
            _state = _state.WonPoint(this);
        }

    }
}