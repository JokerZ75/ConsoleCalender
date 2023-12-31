class Day
{

    int _dayOfMonth;
    public int dayOfMonth
    {
        get
        {
            return _dayOfMonth;
        }
    }

    List<Event> _eventsOfDay = new List<Event>();

    public List<Event> eventsOfDay
    {
        get
        {
            return _eventsOfDay;
        }
    }

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

    public bool hasEvents()
    {
        return _eventsOfDay.Count > 0;
    }

    public override string ToString()
    {
        if (dayOfMonth < 10)
        {
            return string.Format("0{0}", dayOfMonth);
        }
        else
        {
            return dayOfMonth.ToString();
        }
    }

}