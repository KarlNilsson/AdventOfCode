using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    public abstract class PuzzleClass : IPuzzle
    {
        protected string Title = "** Not yet solved **";
        public string GetTitle()
        {
            return Title;
        }

        public abstract string Run();
    }
}
