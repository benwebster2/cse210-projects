public class SimpleGoal : Goal
{
    private bool bwIsComplete;

    public SimpleGoal(string bwName, string bwDescription, string bwPoints) 
        : base(bwName, bwDescription, bwPoints)
    {
        bwIsComplete = false;
    }

    public override void RecordEvent()
    {
        bwIsComplete = true;
    }

    public override bool IsComplete()
    {
        return bwIsComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{bwShortName},{bwDescription},{bwPoints},{bwIsComplete}";
    }
}