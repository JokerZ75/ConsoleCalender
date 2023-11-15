class Year{

    int _yearNumber;
    public int yearNumber
    {
        get
        {
            return _yearNumber;
        }
    }

    Dictionary<int, Month> _monthsOfYear = new Dictionary<int, Month>();
    public Dictionary<int, Month> monthsOfYear
    {
        get
        {
            return _monthsOfYear;
        }

    }

    public Year(int yearNumber)
    {
        _yearNumber = yearNumber;;
        for (int i = 1; i <= 12; i++)
        {
            _monthsOfYear.Add(i, new Month(i, yearNumber));
        }
    }

    public override string ToString()
    {
        return yearNumber.ToString();
    }
    
    
}