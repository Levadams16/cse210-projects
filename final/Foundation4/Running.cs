using System;

public class Running : Activity
{
    private double _distance; // miles

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this._distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetMinutes()} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}