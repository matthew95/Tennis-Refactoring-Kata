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

        private static bool diffeq(int p1, int p2, int to)
        {
            return (p1 - p2) == to || (p2 - p1) == to;
        }
        
        private static bool diffeqgt(int p1, int p2, int than)
        {
            return (p1 - p2) >= than || (p2 - p1) >= than;
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
                if ((game._player1.Score >= 3 || game._player2.Score >= 3) && diffeq(game._player1.Score, game._player2.Score, 0))
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
                var lead = game._player1.Score > game._player2.Score ? game._player1.Name : game._player2.Name;
                return "Advantage " + lead;
            }

            public IState WonPoint(TennisGame3 game)
            {
                if (diffeq(game._player1.Score, game._player2.Score, 0))
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
                var lead = game._player1.Score > game._player2.Score ? game._player1.Name : game._player2.Name;
                return "Win for " + lead;
            }

            public IState WonPoint(TennisGame3 game)
            {
                return this;
            }
        }
        

        public string GetScore()
        {
            // if ((_player1.Score > 2 || _player2.Score > 2) && diffeq(_player1.Score, _player2.Score, 0))
            //     return "Deuce";
            //
            //
            // if ((_player1.Score > 3 || _player2.Score > 3) && diffeq(_player1.Score, _player2.Score, 1))
            // {
            //     var lead = _player1.Score > _player2.Score ? _player1.Name : _player2.Name;
            //     return "Advantage " + lead;
            // }
            //
            // if ((_player1.Score > 3 || _player2.Score > 3) && diffeqgt(_player1.Score, _player2.Score, 2))
            // {
            //     var lead = _player1.Score > _player2.Score ? _player1.Name : _player2.Name;
            //     return "Win for " + lead;
            // }
            
            
            
            return _state.GetScore(this);
            // string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
            // return (_player1.Score == _player2.Score) ? p[_player1.Score] + "-All" : p[_player1.Score] + "-" + p[_player2.Score];
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
                _player1.Score += 1;
            else if (playerName == _player2.Name)
                _player2.Score += 1;
            
            _state = _state.WonPoint(this);
        }

    }
}