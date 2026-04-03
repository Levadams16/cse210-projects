public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this._weather = weather;
    }

    public string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather: {_weather}";
    }
}