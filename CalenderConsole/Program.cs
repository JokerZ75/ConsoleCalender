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
    }
    // Catch for if console too small
    catch (ArgumentOutOfRangeException e)
    {
        // hacky way to clear console because need to as would only be called if console too small once its already writing to console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Console too small. Please resize and try again.");
        Console.ResetColor();
        return;
    }
    catch (Exception e)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error occured. Message: " + e.Message);
        Console.ResetColor();
        return;
    }
    lastSelected = actions.Keys.ToList().IndexOf(choice);
    actions[choice]();


}

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
    if (selectDate == -1) return; // Pressed escape

    // Format the selected date to be displayed
    string selectDateStr = selectDate.ToString();
    if (selectDate < 10) selectDateStr = "0" + selectDateStr;


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
            ConsoleDisplay.DisplayCalender(cal); Console.WriteLine($"\nSelected Date: {selectDateStr}-{cal.currentMonth}-{cal.currentYear}\n");
            choice = ConsoleDisplay.DisplayCalenderOptions(actions, lastSelected);
        }
        // Catch for if console too small
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Console too small. Please resize and try again.");
            Console.ResetColor();
            return;
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error occured. Message: " + e.Message);
            Console.ResetColor();
            return;
        }
        if (choice == "Return To Calender" || lastSelected == -1)
        {
            break;
        }
        lastSelected = actions.Keys.ToList().IndexOf(choice);
        actions[choice]();
    }
}