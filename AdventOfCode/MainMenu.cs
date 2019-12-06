using Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class MainMenu
    {
        private string Logo { get; set; }
        internal void Run()
        {
            DisplayLogo();
            var calendarFactory = new CalendarFactory();
            while (true)
            {
                AwaitKeyPress();
                DisplayMenu(calendarFactory.GetAllPuzzles());
                var option = GetUserInput();
                Console.WriteLine(new string('-', 50));
                if (int.TryParse(option, out int day))
                {
                    if (day == 0)
                    {
                        break;
                    }
                    calendarFactory.Day = (PuzzleEnum)day;
                    var todaysPuzzle = calendarFactory.GetPuzzle();
                    RunPuzzle(todaysPuzzle);
                }
                else if (string.Compare(option, "i") == 0)
                {
                    Console.WriteLine(Intcode.IntcodeTests.RunTests());
                }
            }
        }

        private void RunPuzzle(IPuzzle puzzle)
        {
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var result = puzzle.Run();
            timer.Stop();
            Console.WriteLine("Puzzle result:");
            Console.WriteLine(result);
            Console.WriteLine($"Time elapsed: {timer.ElapsedMilliseconds}ms");
        }

        private string GetUserInput()
        {
            int option;
            string input;
            do
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 0 && option <= 24)
                {
                    break;
                }
                else if (string.Compare("i", input, true) == 0)
                {
                    break;
                }
                Console.WriteLine("Incorrect input");

            } while (true);
            return input;
        }

        private void DisplayLogo()
        {
            if (Logo == null)
            {
                Logo = System.IO.File.ReadAllText("resources/Misc/Logo.txt");
            }
            Console.WriteLine(Logo);
        }

        private void AwaitKeyPress()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(true);
        }


        private void DisplayMenu(List<IPuzzle> puzzles)
        {
            for (int i = 0; i < puzzles.Count; i++)
            {
                Console.WriteLine($"December {i + 1}:\t {puzzles[i].GetTitle()}");
            }
            Console.WriteLine("For running tests on the Intcode Machine, press 'i'");
            Console.WriteLine("\n");
            Console.WriteLine("Enter the number of the day you want to run.");
            Console.WriteLine("\nEnter '0' to exit");
        }
    }
}
