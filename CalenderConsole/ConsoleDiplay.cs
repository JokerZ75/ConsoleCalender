using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class ConsoleDisplay
{

    // Github co-pilot did assist with this method, However, I had to debug and edit it as it gave a unwanted result.
    public static int DaysInMonth(string[] options)
    {
        int lineSpacing = 5;
        int numberOptionsPerLine = 7;

        int selected = 0;
        ConsoleKey key;
        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((i % numberOptionsPerLine) * lineSpacing, i / numberOptionsPerLine);
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

    public static void DisplayCalender(Calender calender) {
        // Display calender in this format
        // --------------------- currentYear -------------------
        //
        // --------------------- currentMonth ------------------
        // days of month with spacing
        Console.Clear();
        Year year = calender.currentYear;
        Month month = calender.currentMonth;
        Console.WriteLine(year.ToString().PadLeft(25, '-').PadRight(50, '-'));
        Console.WriteLine();
        Console.WriteLine(month.ToString().PadLeft(24, '-').PadRight(50, '-'));
        Console.WriteLine("Mon\tTue\tWed\tThu\tFri\tSat\tSun");
        int numberOfDays = month.daysOfMonth.Count;
        for (int i = 1; i <= numberOfDays; i++)
        {
            Day day = month.daysOfMonth[i];
            Console.Write(day.ToString() + "\t");
            if (i % 7 == 0)
            {
                Console.WriteLine();
            }
        }          
    }
}
