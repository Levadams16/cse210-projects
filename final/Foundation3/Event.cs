public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this._title = title;
        this._description = description;
        this._date = date;
        this._time = time;
        this._address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public string GetShortDescription(string eventType)
    {
        return $"Event Type: {eventType}\nTitle: {_title}\nDate: {_date}";
    }

    protected string GetTitle() => _title;
    protected string GetDescription() => _description;
    protected string GetDate() => _date;
    protected string GetTime() => _time;
    protected Address GetAddress() => _address;
}