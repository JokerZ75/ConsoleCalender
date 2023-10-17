class Day
{

    int _dayOfMonth;
    public int dayOfMonth
    {
        get
        {
            return _dayOfMonth;
        }
        set
        {
            _dayOfMonth = value;
        }
    }

    List<Event> _eventsOfDay = new List<Event>();

    public Day(int dayOfMonth)
    {
         _dayOfMonth = dayOfMonth;
    }

    public void AddEvent(string name, string description)
    {
        Event newEvent = new Event(name, description);
        _eventsOfDay.Add(newEvent);
    }

    public void RemoveEvent(Event eventToRemove)
    {
        _eventsOfDay.Remove(eventToRemove);
    }

    public override string ToString()
    {
        return dayOfMonth.ToString();
    }

}