public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetDetails()}|{GetPoints()}|{_isComplete}";
    }

    public static SimpleGoal FromString(string[] parts)
    {
        string[] detail = parts[1].Split(" (");
        string name = detail[0];
        string desc = detail[1].TrimEnd(')');
        int points = int.Parse(parts[2]);
        bool complete = bool.Parse(parts[3]);

        SimpleGoal g = new SimpleGoal(name, desc, points);
        if (complete) g.RecordEvent();

        return g;
    }
}