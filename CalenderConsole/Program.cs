Calender cal = new Calender();

string[] daysInMonth = new string[31];
for (int i = 0; i < 31; i++)
{
    daysInMonth[i] = (i + 1).ToString();
}

int option = ConsoleDisplay.DaysInMonth(daysInMonth);
Console.WriteLine(option);

ConsoleDisplay.DisplayCalender(cal);