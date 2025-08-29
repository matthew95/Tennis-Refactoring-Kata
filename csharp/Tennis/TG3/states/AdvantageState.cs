namespace Tennis.TG3;

public class AdvantageState: IState
{
    public string GetScore(StateContext context)
    {
        return "Advantage " + Helper.GetLeadName(context.Player1, context.Player2);
    }

    public IState WonPoint(StateContext context)
    {
        if (context.Player1.Score == context.Player2.Score)
        {
            return new DeuceState();
        }

        return new WonState();
    }
}