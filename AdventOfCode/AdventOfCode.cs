using System;
using CommandLine;
using Calendar;


namespace AdventOfCode
{
    public class Options
    {
        [Option('d', "day", Required = false, HelpText = "Specifies which day of AdventCode to play")]
        public int day { get; set; }
    }

    public class AdventOfCode
    {
        static void Main(string[] args)
        {
            int day = -1;
            Console.WriteLine("Welcome to advent of code!");
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
            {
                if (o.day >= 1 && o.day <= 24)
                {
                    Console.WriteLine($"Result for day {o.day}:");
                    day = o.day;
                }
                else
                {
                    bool inputCorrect = false;
                    do
                    {
                        Console.WriteLine("It seems that you have entered an incorrect value, please enter a day between 1 and 24");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out day) && day >= 1 && day <= 24)
                        {
                            inputCorrect = true;
                        }

                    } while (inputCorrect == false);

                }
            });
            var calendarFactory = new CalendarFactory(day);
            var todaysPuzzle = calendarFactory.GetPuzzle();
            var output = todaysPuzzle.Run();
            Console.WriteLine($"Output for day {day}: {output}");
            Console.ReadLine();
        }
    }
}
