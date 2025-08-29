namespace Tennis.TG3;

public interface IState
{
    public string GetScore(StateContext context);
    public IState WonPoint(StateContext context);
}