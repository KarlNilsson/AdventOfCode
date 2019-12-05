using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.December03
{
    using Wires = List<string[]>;
    public static class WireParser
    {
        public static Wires Parse(string WireScheme)
        {
            var wireList = new Wires();
            var wires = WireScheme.Split("\n");
            var wire1 = wires[0].Split(",");
            var wire2 = wires[1].Split(",");
            wireList.Add(wire1);
            wireList.Add(wire2);
            return wireList;
        }
    }
}
