
class ConsoleDisplay
{

    static int MovementOptions(int selected, int numberOptionsPerLine, int optionsLength, int lineSpacing, int startY, string[] options)
    {
        ConsoleKey key;
        do
        {
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((i) % numberOptionsPerLine * lineSpacing, startY + (i) / numberOptionsPerLine);

                if (i == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selected >= numberOptionsPerLine)
                    {
                        selected -= numberOptionsPerLine;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selected + numberOptionsPerLine < options.Length)
                    {
                        selected += numberOptionsPerLine;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (selected > 0)
                    {
                        selected--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (selected < options.Length - 1)
                    {
                        selected++;
                    }
                    break;
                case ConsoleKey.Enter:
                    break;
                default:
                    break;
            }
        } while (key != ConsoleKey.Enter);

        return selected;
    }


    public static int DaysInMonthSelection(Calender calender)
    {
        int lineSpacing = 8;
        int numberOptionsPerLine = 7;
        int startY = 4;

        int selected = 0;
        ConsoleKey key;
        Console.CursorVisible = false;

        Year year = calender.currentYear;
        Month month = calender.currentMonth;
        DateTime date = new DateTime(year.yearNumber, month.monthNumber, 1);
        int dayOfWeek = (int)date.DayOfWeek;
        if (dayOfWeek == 0)
        {
            dayOfWeek = 7;
        }
        dayOfWeek -= 1;


        Day[] options = month.daysOfMonth.Values.ToArray();
        do
        {
            Console.Clear();
            Console.WriteLine(year.ToString().PadLeft(25, '-').PadRight(50, '-'));
            Console.WriteLine();
            Console.WriteLine(month.ToString().PadLeft(24, '-').PadRight(50, '-'));
            Console.WriteLine("Mon\tTue\tWed\tThu\tFri\tSat\tSun");
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((i + dayOfWeek) % numberOptionsPerLine * lineSpacing, startY + (i + dayOfWeek) / numberOptionsPerLine);

                if (i == selected && options[i].hasEvents())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                }
                else if (i == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (options[i].hasEvents())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                }
                else Console.ResetColor();


                Console.Write(options[i].ToString());

                Console.ResetColor();
            }
            Console.WriteLine($"\nNumber Of Events on Day: {options[selected].eventsOfDay.Count}");

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selected >= numberOptionsPerLine)
                    {
                        selected -= numberOptionsPerLine;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selected + numberOptionsPerLine < options.Length)
                    {
                        selected += numberOptionsPerLine;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (selected > 0)
                    {
                        selected--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (selected < options.Length - 1)
                    {
                        selected++;
                    }
                    break;
                case ConsoleKey.Enter:
                    break;
                default:
                    break;
            }
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return selected + 1;
    }

    public static void DisplayCalender(Calender calender)
    {
        // Display calender in this format
        // --------------------- currentYear -------------------
        //
        // --------------------- currentMonth ------------------
        // days of month with spacing
        int lineSpacing = 8;
        int numberOptionsPerLine = 7;
        int startY = 4;
        Console.Clear();
        Year year = calender.currentYear;
        Month month = calender.currentMonth;
        DateTime date = new DateTime(year.yearNumber, month.monthNumber, 1);
        int dayOfWeek = (int)date.DayOfWeek;
        if (dayOfWeek == 0)
        {
            dayOfWeek = 7;
        }
        dayOfWeek -= 1;

        Console.WriteLine(year.ToString().PadLeft(25, '-').PadRight(50, '-'));
        Console.WriteLine();
        Console.WriteLine(month.ToString().PadLeft(24, '-').PadRight(50, '-'));
        Console.WriteLine("Mon\tTue\tWed\tThu\tFri\tSat\tSun");
        Day[] options = month.daysOfMonth.Values.ToArray();
        for (int i = 0; i < options.Length; i++)
        {
            Console.SetCursorPosition((i + dayOfWeek) % numberOptionsPerLine * lineSpacing, startY + (i + dayOfWeek) / numberOptionsPerLine);
            if (options[i].hasEvents())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*");
            }
            else Console.ResetColor();

            Console.Write(options[i].ToString());
        }

    }

    public static string DisplayCalenderOptions(Dictionary<string, Action> actions, int lastSelected = 0)
    {
        int lineSpacing = 22;
        int numberOptionsPerLine = 3;
        int startY = 11;


        int selected = lastSelected;
        Console.CursorVisible = false;
        string[] options = actions.Keys.ToArray();

        selected = MovementOptions(selected, numberOptionsPerLine, options.Length, lineSpacing, startY, options);


        Console.CursorVisible = true;

        return options[selected];
    }

    public static Event SelectEventToDelete(Dictionary<string, Event> events)
    {
        int lineSpacing = 22;
        int numberOptionsPerLine = 2;
        int startY = 11;

        int selected = 0;
        Console.CursorVisible = false;
        string[] options = events.Values.Select(e => $"{e.name} - {e.description}").ToArray();

        selected = MovementOptions(selected, numberOptionsPerLine, options.Length, lineSpacing, startY, options);
        return events[options[selected].Split('-')[0].Trim()];
    }

}
// Test change



