using System;

namespace Calendar
{
    public enum PuzzleEnum
    {
        December1,
        December2,
        December3,
        December4,
        December5,
        December6,
        December7,
        December8,
        December9,
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
    public interface Puzzle {
        public string Run();
    }
    public class CalendarFactory
    {
        public PuzzleEnum day { get; private set; }
        public CalendarFactory(int day)
        {
            this.day = (PuzzleEnum)(day - 1);
        }

        public Puzzle GetPuzzle()
        {
            switch (this.day)
            {
                case PuzzleEnum.December1:
                    return new December1Puzzle();
                case PuzzleEnum.December2:
                    return new December2Puzzle();
                case PuzzleEnum.December3:
                case PuzzleEnum.December4:
                case PuzzleEnum.December5:
                case PuzzleEnum.December6:
                case PuzzleEnum.December7:
                case PuzzleEnum.December8:
                case PuzzleEnum.December9:
                case PuzzleEnum.December10:
                case PuzzleEnum.December11:
                case PuzzleEnum.December12:
                case PuzzleEnum.December13:
                case PuzzleEnum.December14:
                case PuzzleEnum.December15:
                case PuzzleEnum.December16:
                case PuzzleEnum.December17:
                case PuzzleEnum.December18:
                case PuzzleEnum.December19:
                case PuzzleEnum.December20:
                case PuzzleEnum.December21:
                case PuzzleEnum.December22:
                case PuzzleEnum.December23:
                case PuzzleEnum.December24:
                default:
                    return null;
            }
        }

    }
}
