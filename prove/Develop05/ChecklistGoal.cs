public class ChecklistGoal : Goal
{
    private int bwAmountCompleted;
    private int bwTarget;
    private int bwBonus;

    public ChecklistGoal(string bwName, string bwDescription, string bwPoints, int bwTarget, int bwBonus) 
        : base(bwName, bwDescription, bwPoints)
    {
        bwAmountCompleted = 0;
        this.bwTarget = bwTarget;
        this.bwBonus = bwBonus;
    }

    public void SetAmountCompleted(int bwAmount)
    {
        bwAmountCompleted = bwAmount;
    }

    public int GetBonus()
    {
        return bwBonus;
    }

    public override void RecordEvent()
    {
        if (bwAmountCompleted < bwTarget)
        {
            bwAmountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return bwAmountCompleted >= bwTarget;
    }

    public override string GetDetailsString()
    {
        string bwBox = IsComplete() ? "[X]" : "[ ]";
        return $"{bwBox} {bwShortName} ({bwDescription}) -- Currently completed: {bwAmountCompleted}/{bwTarget}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{bwShortName},{bwDescription},{bwPoints},{bwAmountCompleted},{bwTarget},{bwBonus}";
    }
}