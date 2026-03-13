public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
    {
        _count++;

        if (_count == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _count >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetDetails()}|{GetPoints()}|{_target}|{_bonus}|{_count}";
    }

    public override string GetProgress()
    {
        return $"-- Completed {_count}/{_target} times";
    }

    public static ChecklistGoal FromString(string[] parts)
    {
        string[] detail = parts[1].Split(" (");
        string name = detail[0];
        string desc = detail[1].TrimEnd(')');
        int points = int.Parse(parts[2]);
        int target = int.Parse(parts[3]);
        int bonus = int.Parse(parts[4]);
        int count = int.Parse(parts[5]);

        ChecklistGoal g = new ChecklistGoal(name, desc, points, target, bonus);

        for (int i = 0; i < count; i++)
            g.RecordEvent();

        return g;
    }
}