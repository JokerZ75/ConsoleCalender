class Calender
{

    Dictionary<int, Year> _years = new Dictionary<int, Year>();

    Year _currentYear;
    public Year currentYear
    {
        get
        {
            return _currentYear;
        }
        set
        {
            _currentYear = value;
        }
    }

    Month _currentMonth;
    public Month currentMonth
    {
        get
        {
            return _currentMonth;
        }
        set
        {
            _currentMonth = value;
        }
    }


    public Calender()
    {
        GenerateYears(DateTime.Now.Year - 10, DateTime.Now.Year + 10);
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

    public void NextYear()
    {
        if (_years.ContainsKey(_currentYear.yearNumber + 1))
        {
            _currentYear = _years[_currentYear.yearNumber + 1];
        }
        else
        {
            _years.Add(_currentYear.yearNumber + 1, new Year(_currentYear.yearNumber + 1));
            _currentYear = _years[_currentYear.yearNumber + 1];
        }
    }
    public void PreviousYear()
    {
        if (_years.ContainsKey(_currentYear.yearNumber - 1))
        {
            _currentYear = _years[_currentYear.yearNumber - 1];
        }
        else
        {
            _years.Add(_currentYear.yearNumber - 1, new Year(_currentYear.yearNumber - 1));
            _currentYear = _years[_currentYear.yearNumber - 1];
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


    public void AddEvent(int day, string name, string description)
    {
        _currentMonth.daysOfMonth[day].AddEvent(name, description);
    }

    public void RemoveEvent(int day, Event eventToRemove)
    {
        _currentMonth.daysOfMonth[day].RemoveEvent(eventToRemove);
    }

}