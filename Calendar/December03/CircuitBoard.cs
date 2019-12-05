using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calendar.December03
{
    // Combine coordmaps into single dictionary
    using CoordMap = Dictionary<ValueTuple<int, int>, int>;
    using Wires = List<string[]>;

    public class CircuitBoard
    {
        private CoordMap _coordA;
        private CoordMap _coordB;
        private Wires _wireList;

        public CircuitBoard(Wires WireList)
        {
            _coordA = new CoordMap();
            _coordB = new CoordMap();
            _wireList = WireList;
        }

        private void AddCoords(CoordMap Map, string[] Wire)
        {
            int x = 0, y = 0, steps = 0;
            foreach (var instruction in Wire)
            {
                switch (instruction[0])
                {
                    case 'U':
                        for (int i = 0; i < int.Parse(instruction.Substring(1)); i++)
                        {
                            Map.TryAdd((x, ++y), ++steps);
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < int.Parse(instruction.Substring(1)); i++)
                        {
                            Map.TryAdd((x, --y), ++steps);
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < int.Parse(instruction.Substring(1)); i++)
                        {
                            Map.TryAdd((++x, y), ++steps);
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < int.Parse(instruction.Substring(1)); i++)
                        {
                            Map.TryAdd((--x, y), ++steps);
                        }
                        break;
                }

            }
        }

        private int GetClosestManhattanDistance()
        {
            var intersections = _coordA.Keys.Intersect(_coordB.Keys);
            var shortestDistance = int.MaxValue;
            shortestDistance = intersections.Min(x => GetManhattanDistance(x.Item1, x.Item2));
            foreach (var intersection in intersections)
            {
                var currentDistance = GetManhattanDistance(
                    intersection.Item1,
                    intersection.Item2
                    );
                if (currentDistance < shortestDistance)
                {
                    shortestDistance = currentDistance;
                }
            }
            return shortestDistance;
        }

        private int GetManhattanDistance(int x, int y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }
        private int GetFewestSteps()
        {
            var intersections = _coordA.Keys.Intersect(_coordB.Keys);
            var fewestSteps = intersections.Min(x => _coordA[x] + _coordB[x]);
            return fewestSteps;
        }

        public string CalculateManhattanDistance()
        {
            AddCoords(_coordA, _wireList[0]);
            AddCoords(_coordB, _wireList[1]);
            var closest = GetClosestManhattanDistance();
            return closest.ToString();
        }

        public string CalculateFewestSteps()
        {
            var fewestSteps = GetFewestSteps();
            return fewestSteps.ToString();
        }
    }
}
