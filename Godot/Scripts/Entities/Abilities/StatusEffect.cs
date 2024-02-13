public class StatusEffect
{
    public Status status { get; set; }
    public int duration { get; set; }

    public override string ToString()
    {
        return $"Status: {status} ({duration} bars)";
    }
}
