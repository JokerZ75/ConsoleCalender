using System.ComponentModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;

class ConsoleDisplay
{


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


        int[] options = month.daysOfMonth.Keys.ToArray();
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
        int[] options = month.daysOfMonth.Keys.ToArray();
        for (int i = 0; i < options.Length; i++)
        {
            Console.SetCursorPosition((i + dayOfWeek) % numberOptionsPerLine * lineSpacing, startY + (i + dayOfWeek) / numberOptionsPerLine);
            Console.Write(options[i]);
        }

    }

    public static string DisplayCalenderOptions(Dictionary<string,Action> actions, int lastSelected = 0)
    {
        int lineSpacing = 22;
        int numberOptionsPerLine = 3;
        int startY = 11;


        int selected = lastSelected;
        ConsoleKey key;
        Console.CursorVisible = false;
        string[] options = actions.Keys.ToArray();
        do
        {
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((i) % numberOptionsPerLine * lineSpacing, startY + (i) / numberOptionsPerLine);

                if (i == selected )
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

        Console.CursorVisible = true;
        
        return options[selected];
    }

}


