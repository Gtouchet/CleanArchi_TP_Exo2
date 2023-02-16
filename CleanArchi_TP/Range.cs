namespace CleanArchi_TP;

public class Range
{
    public int Min { get; }
    public int Max { get; }

    public Range(int min, int max)
	{
        if (min < 0 || max <= min)
        {
            throw new ArgumentException("Invalid range");
        }
        this.Min = min;
        this.Max = max;
    }
}
