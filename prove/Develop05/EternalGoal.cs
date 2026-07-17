public class EternalGoal : Goal
{
    public EternalGoal(string bwName, string bwDescription, string bwPoints) 
        : base(bwName, bwDescription, bwPoints)
    {
    }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{bwShortName},{bwDescription},{bwPoints}";
    }
}