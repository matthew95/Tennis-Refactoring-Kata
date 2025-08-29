using Tennis.TG3;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private IState _state = new StartState();
        private readonly Player _player1;
        private readonly Player _player2;
        
        public TennisGame3(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };
        }
        
        public string GetScore()
        {
            return _state.GetScore(new StateContext { Player1 = _player1, Player2 = _player2 });
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
            
            _state = _state.WonPoint(new StateContext { Player1 = _player1, Player2 = _player2});
        }

    }
}