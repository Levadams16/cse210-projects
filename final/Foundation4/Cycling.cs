using System;

public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        this._speed = _speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetMinutes()} min)- Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}