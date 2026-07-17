public abstract class Goal
{
    protected string bwShortName;
    protected string bwDescription;
    protected string bwPoints;

    public Goal(string bwName, string bwDescription, string bwPoints)
    {
        bwShortName = bwName;
        this.bwDescription = bwDescription;
        this.bwPoints = bwPoints;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public string GetShortName()
    {
        return bwShortName;
    }

    public int GetPoints()
    {
        return int.Parse(bwPoints);
    }

    public virtual string GetDetailsString()
    {
        string bwBox = IsComplete() ? "[X]" : "[ ]";
        return $"{bwBox} {bwShortName} ({bwDescription})";
    }
}