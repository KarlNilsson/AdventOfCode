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
                if (option == 0)
                {
                    return;
                }
                calendarFactory.Day = (PuzzleEnum)option;
                var todaysPuzzle = calendarFactory.GetPuzzle();
                RunPuzzle(todaysPuzzle);
            }
        }

        private void RunPuzzle(IPuzzle puzzle)
        {
            var result = puzzle.Run();
            Console.WriteLine("Puzzle result:");
            Console.WriteLine(result);
        }

        private int GetUserInput()
        {
            int option;
            do
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 0 && option <= 24)
                {
                    break;
                }
                Console.WriteLine("Incorrect input");

            } while (true);
            return option;
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
            Console.WriteLine("\n");
            Console.WriteLine("Enter the number of the day you want to run.");
            Console.WriteLine("\nEnter '0' to exit");
        }
    }
}
