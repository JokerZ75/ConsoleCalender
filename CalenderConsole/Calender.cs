class Calender
{
    Dictionary<int, Year> _years = new Dictionary<int, Year>();

    Year _currentYear;
    public Year CurrentYear
    {
        get
        {
            return _currentYear;
        }
    }

    Month _currentMonth;
    public Month CurrentMonth
    {
        get
        {
            return _currentMonth;
        }
    }


    public Calender()
    {
        GenerateYears(DateTime.Now.Year - 5, DateTime.Now.Year + 5);
        _currentYear = _years[DateTime.Now.Year];
        _currentMonth = _currentYear.monthsOfYear[DateTime.Now.Month];
    }

    void GenerateYears(int startYear, int endYear)
    {
        for (int i = startYear; i <= endYear; i++)
        {
            _years.Add(i, new Year(i));
        }
    }

    Year GenerateNextYear()
    {
        int lastYear = _years.Keys.Max();
        _years.Add(lastYear + 1, new Year(lastYear + 1));
        return _years[lastYear + 1];
    }

    Year GeneratePreviousYear()
    {
        int firstYear = _years.Keys.Min();
        _years.Add(firstYear - 1, new Year(firstYear - 1));
        return _years[firstYear - 1];
    }

    public void NextYear()
    {
        if (_years.ContainsKey(_currentYear.yearNumber + 1))
        {
            _currentYear = _years[_currentYear.yearNumber + 1];
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber];
        }
        else
        {
            _currentYear = GenerateNextYear();
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber];
        }
    }
    public void PreviousYear()
    {
        if (_years.ContainsKey(_currentYear.yearNumber - 1))
        {
            _currentYear = _years[_currentYear.yearNumber - 1];
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber];
        }
        else
        {
            _currentYear = GeneratePreviousYear();
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber];
        }
    }

    public void NextMonth()
    {
        if (_currentMonth.monthNumber == 12)
        {
            NextYear();
            _currentMonth = _currentYear.monthsOfYear[1];
        }
        else
        {
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber + 1];
        }
    }

    public void PreviousMonth()
    {
        if (_currentMonth.monthNumber == 1)
        {
            PreviousYear();
            _currentMonth = _currentYear.monthsOfYear[12];
        }
        else
        {
            _currentMonth = _currentYear.monthsOfYear[_currentMonth.monthNumber - 1];
        }
    }

    public void SelectCurrentDate()
    {
        _currentYear = _years[DateTime.Now.Year];
        _currentMonth = _currentYear.monthsOfYear[DateTime.Now.Month];
    }


    public void AddEvent(int day, string name, string description)
    {
        _currentMonth.daysOfMonth[day].AddEvent(name, description);
    }

    public void RemoveEvent(int day, Event eventToRemove)
    {
        _currentMonth.daysOfMonth[day].RemoveEvent(eventToRemove);
    }

    public List<Event> GetEventsOfDay(int day)
    {
        return _currentMonth.daysOfMonth[day].eventsOfDay;
    }

    public Dictionary<string, List<Event>> GetEventsOfMonth()
    {
        Dictionary<string, List<Event>> events = new Dictionary<string, List<Event>>();
        foreach (Day day in _currentMonth.daysOfMonth.Values)
        {
            foreach (Event e in day.eventsOfDay)
            {
                if (events.ContainsKey(day.dayOfMonth.ToString()))
                {
                    events["day " + day.dayOfMonth.ToString()].Add(e);
                }
                else
                {
                    events.Add("day " + day.dayOfMonth.ToString(), new List<Event>() { e });
                }
            }
        }
        return events;
    }

    public Dictionary<string, List<Event>> GetEventsOfYear()
    {
        Dictionary<string, List<Event>> events = new Dictionary<string, List<Event>>();
        foreach (Month month in _currentYear.monthsOfYear.Values) // Gross nested loops but it works
        {
            foreach (Day day in month.daysOfMonth.Values)
            {
                foreach (Event e in day.eventsOfDay)
                {
                    if (events.ContainsKey($"{month.monthNumber}-{day.dayOfMonth}"))
                    {
                        events[$"day {day.dayOfMonth} of month {month.monthNumber}"].Add(e);
                    }
                    else
                    {
                        events.Add($"day {day.dayOfMonth} of month {month.monthNumber}", new List<Event>() { e });
                    }
                }
            }

        }
        return events;
    }




}