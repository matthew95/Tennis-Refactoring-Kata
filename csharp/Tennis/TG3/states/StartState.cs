using Tennis.TG3.states;

namespace Tennis.TG3;

public class StartState : IState
{
    public string GetScore(StateContext context)
    {
        string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
        return (context.Player1.Score == context.Player2.Score) ? p[context.Player1.Score] + "-All" : p[context.Player1.Score] + "-" + p[context.Player2.Score];
    }

    public IState WonPoint(StateContext context)
    {
        if ((context.Player1.Score >= 3 || context.Player2.Score >= 3) && context.Player1.Score == context.Player2.Score)
        {
            return new DeuceState();
        }

        if (context.Player1.Score == 4 || context.Player2.Score == 4)
        {
            return new WonState();
        }
                
        return this;
    }
}