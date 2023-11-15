class Month {
    Dictionary<int, Day> _daysOfMonth = new Dictionary<int, Day>();
    public Dictionary<int, Day> daysOfMonth
    {
        get
        {
            return _daysOfMonth;
        }
    }

    int _monthNumber;
    public int monthNumber
    {
        get
        {
            return _monthNumber;
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
        if (monthNumber < 10)
        {
            return string.Format("0{0}", monthNumber);
        }
        else
        {
            return monthNumber.ToString();
        }
    }

}