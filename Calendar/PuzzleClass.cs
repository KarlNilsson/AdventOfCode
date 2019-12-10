using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    public abstract class PuzzleClass : IPuzzle
    {
        protected string Title = "** Not yet solved **";
        protected StringBuilder sb = new StringBuilder();
        public string GetTitle()
        {
            return Title;
        }

        public abstract string Run();
    }
}
