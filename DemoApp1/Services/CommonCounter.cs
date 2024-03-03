namespace DemoApp.Services;

public class CommonCounter : ICounter
{
    private int current;

    public int CountNext(string name)
    {
        return Interlocked.Increment(ref current);
    }
}