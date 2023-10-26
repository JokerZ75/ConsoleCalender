using System.Runtime.InteropServices;


(string, string) CreateEvent()
{
    string name = "";
    string description = "";
    Console.WriteLine("");
    Console.Write("Enter event name (c to cancel): ");
    name = Console.ReadLine();
    if (name == "c")
    {
        return ("", "");
    }
    Console.WriteLine("");
    Console.WriteLine("Enter event description (c to cancel): ");
    description = Console.ReadLine();
    if (description == "c")
    {
        return ("", "");
    }
    return (name, description);
}

void selectDate(Calender cal)
{
    int selectDate = ConsoleDisplay.DaysInMonthSelection(cal);
    // These are the actions that can be taken on a selected date
    Dictionary<string, Action> actions = new Dictionary<string, Action>(){
        {"Add Event", () => {
            (string name, string description) = CreateEvent();
            if (name != "" && description != "") cal.AddEvent(selectDate, name, description);
        }},
        {
            "Remove Event", () => {
                Dictionary<string, Event> events = new Dictionary<string, Event>();
                cal.currentMonth.daysOfMonth[selectDate].eventsOfDay.ForEach((Event e) => {
                    events.Add(e.name, e);
                });
                ConsoleDisplay.DisplayCalender(cal);
                Event eventToDelete = ConsoleDisplay.SelectEventToDelete(events);
                cal.RemoveEvent(selectDate, eventToDelete);
            }
        },
        {"Return To Calender", () => {
        }}
    };

    // Display the selected date and the actions that can be taken on it
    string choice = "";
    int lastSelected = 0;
    while (true)
    {
        try
        {
            ConsoleDisplay.DisplayCalender(cal);
            choice = ConsoleDisplay.DisplayCalenderOptions(actions, lastSelected);
            Console.WriteLine($"\nSelected Date: {selectDate}");
            lastSelected = actions.Keys.ToList().IndexOf(choice);
            if (choice == "Return To Calender")
            {
                break;
            }
            actions[choice]();
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }
    }
}


Calender cal = new Calender();
Dictionary<string, Action> actions = new Dictionary<string, Action>(){
    {"Previous Year", cal.PreviousYear},
    {"Select Date", () => selectDate(cal)},
    {"Next Year", cal.NextYear},
    {"Previous Month", cal.PreviousMonth},
    {"Return To Current", cal.SelectCurrentDate},
    {"Next Month", cal.NextMonth},
    {"Exit", () => Environment.Exit(0)}

};
string choice = "";
int lastSelected = 0;
cal.AddEvent(2, "Test", "Test Description");

while (true)
{
    try
    {
        ConsoleDisplay.DisplayCalender(cal);
        choice = ConsoleDisplay.DisplayCalenderOptions(actions, lastSelected);
        lastSelected = actions.Keys.ToList().IndexOf(choice);
        actions[choice]();
    }
    catch
    {
        Console.WriteLine("Invalid input");
    }
}
