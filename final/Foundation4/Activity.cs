using System;

public class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        this._date = date;
        this._minutes = minutes;
    }

    protected int GetMinutes() => _minutes;
    protected string GetDate() => _date;

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        return $"{_date} Activity ({_minutes} min)";
    }
}