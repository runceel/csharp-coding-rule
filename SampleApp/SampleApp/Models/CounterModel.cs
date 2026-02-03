namespace SampleApp.Models;

public class CounterModel
{
    public int CurrentCount { get; private set; }

    public void Increment()
    {
        CurrentCount++;
    }

    public void reset()
    {
        CurrentCount = 0;
    }
}
