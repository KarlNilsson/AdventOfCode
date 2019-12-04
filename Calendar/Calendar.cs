using System;
using System.Collections.Generic;

namespace Calendar
{
    public enum PuzzleEnum
    {
        December01 = 1,
        December02,
        December03,
        December04,
        December05,
        December06,
        December07,
        December08,
        December09,
        December10,
        December11,
        December12,
        December13,
        December14,
        December15,
        December16,
        December17,
        December18,
        December19,
        December20,
        December21,
        December22,
        December23,
        December24
    };
    public interface IPuzzle {
        public string Run();
        public string GetTitle();
    }
    public class CalendarFactory
    {
        public PuzzleEnum Day { get; set; }
        private List<IPuzzle> _puzzles;
        public CalendarFactory()
        {
            _puzzles = new List<IPuzzle>();
        }

        public IPuzzle GetPuzzle()
        {
            switch (Day)
            {
                case PuzzleEnum.December01:
                    return new December01Puzzle();
                case PuzzleEnum.December02:
                    return new December02Puzzle();
                case PuzzleEnum.December03:
                    return new December03Puzzle();
                case PuzzleEnum.December04:
                    return new December04Puzzle();
                case PuzzleEnum.December05:
                    return new December05Puzzle();
                case PuzzleEnum.December06:
                    return new December06Puzzle();
                case PuzzleEnum.December07:
                    return new December07Puzzle();
                case PuzzleEnum.December08:
                    return new December08Puzzle();
                case PuzzleEnum.December09:
                    return new December09Puzzle();
                case PuzzleEnum.December10:
                    return new December10Puzzle();
                case PuzzleEnum.December11:
                    return new December11Puzzle();
                case PuzzleEnum.December12:
                    return new December12Puzzle();
                case PuzzleEnum.December13:
                    return new December13Puzzle();
                case PuzzleEnum.December14:
                    return new December14Puzzle();
                case PuzzleEnum.December15:
                    return new December15Puzzle();
                case PuzzleEnum.December16:
                    return new December16Puzzle();
                case PuzzleEnum.December17:
                    return new December17Puzzle();
                case PuzzleEnum.December18:
                    return new December18Puzzle();
                case PuzzleEnum.December19:
                    return new December19Puzzle();
                case PuzzleEnum.December20:
                    return new December20Puzzle();
                case PuzzleEnum.December21:
                    return new December21Puzzle();
                case PuzzleEnum.December22:
                    return new December22Puzzle();
                case PuzzleEnum.December23:
                    return new December23Puzzle();
                case PuzzleEnum.December24:
                    return new December24Puzzle();
                default:
                    return null;
            }
        }

        public List<IPuzzle> GetAllPuzzles()
        {
            if (_puzzles.Count == 0)
            {
                var puzzleEnums = (PuzzleEnum[])Enum.GetValues(typeof(PuzzleEnum));
                foreach (var pEnum in puzzleEnums)
                {
                    Day = pEnum;
                    _puzzles.Add(GetPuzzle());
                }
            }
            return _puzzles;
        }

    }
}
