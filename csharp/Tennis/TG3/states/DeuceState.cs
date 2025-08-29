namespace Tennis.TG3;

public class DeuceState: IState
{
    public string GetScore(StateContext context)
    {
        return "Deuce";
    }

    public IState WonPoint(StateContext context)
    {
        return new AdvantageState();
    }
}