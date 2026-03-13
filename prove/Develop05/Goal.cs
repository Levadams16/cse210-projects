using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetDetails()
    {
        return $"{_name} ({_description})";
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public string GetStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public abstract string GetStringRepresentation();
    public virtual string GetProgress()
    {
        return "";
    }
}