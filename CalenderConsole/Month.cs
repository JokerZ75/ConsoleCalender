class Month {
    Dictionary<int, Day> _daysOfMonth = new Dictionary<int, Day>();
    public Dictionary<int, Day> daysOfMonth
    {
        get
        {
            return _daysOfMonth;
        }
        set
        {
            _daysOfMonth = value;
        }
    }

    int _monthNumber;
    public int monthNumber
    {
        get
        {
            return _monthNumber;
        }
        set
        {
            _monthNumber = value;
        }
    }


    public Month(int monthNumber, int year)
    {
        _monthNumber = monthNumber;
        int daysInMonth = DateTime.DaysInMonth(year, monthNumber);
        for (int i = 1; i <= daysInMonth; i++)
        {
            _daysOfMonth.Add(i, new Day(i));
        }
    }

    public override string ToString()
    {
        return monthNumber.ToString();
    }

}