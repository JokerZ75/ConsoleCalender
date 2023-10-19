using System.Runtime.InteropServices;

void selectDate(Calender cal)
{
    ConsoleDisplay.DaysInMonthSelection(cal);
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
