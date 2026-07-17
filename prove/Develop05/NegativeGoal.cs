public class NegativeGoal : Goal
{
    public NegativeGoal(string bwName, string bwDescription, string bwPoints) 
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

    public override string GetDetailsString()
    {
        return $"[-] {bwShortName} ({bwDescription}) [Loses {bwPoints} points]";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{bwShortName},{bwDescription},{bwPoints}";
    }
}