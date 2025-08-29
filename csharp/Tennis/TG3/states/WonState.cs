namespace Tennis.TG3.states;

public class WonState: IState
{
    public string GetScore(StateContext context)
    {
        return "Win for " + Helper.GetLeadName(context.Player1, context.Player2);
    }

    public IState WonPoint(StateContext context)
    {
        return this;
    }
}