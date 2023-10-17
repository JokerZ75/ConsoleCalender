class Event
{

    string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    string _description;
    public string description
    {
        get
        {
            return _description;
        }
        set
        {
            _name = value;
        }
    }
    public Event( string name, string description)
    {
        _name = name;
        _description = description;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1}", name, description);
    }



}