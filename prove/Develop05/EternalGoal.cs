public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetDetails()}|{GetPoints()}";
    }

    public static EternalGoal FromString(string[] parts)
    {
        string[] detail = parts[1].Split(" (");
        string name = detail[0];
        string desc = detail[1].TrimEnd(')');
        int points = int.Parse(parts[2]);

        return new EternalGoal(name, desc, points);
    }
}