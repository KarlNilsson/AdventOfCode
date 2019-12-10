using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calendar.December06
{
    using PlanetList = Tuple<List<string>, List<string>>;
    public class OrbitCalculator
    {
        private Dictionary<string, PlanetList> _planets;

        public OrbitCalculator()
        {
            _planets = new Dictionary<string, PlanetList>();
        }

        public void AddPlanets(string[] input)
        {
            foreach (var relation in input)
            {
                var planetsInput = relation.Split(')');
                var planet1 = planetsInput[0];
                var planet2 = planetsInput[1];

                if (!_planets.ContainsKey(planet1))
                {
                    _planets.Add(planet1, new PlanetList(new List<string>(), new List<string>()));
                }
                if (!_planets.ContainsKey(planet2))
                {
                    _planets.Add(planet2, new PlanetList(new List<string>(), new List<string>()));
                }

                _planets[planet1].Item1.Add(planet2);
                _planets[planet2].Item2.Add(planet1);

            }

        }

        public int ShortestPath(string planetStart, string planetDest)
        {
            int distance = 0;
            var visitedPlanets = new List<string> { planetStart };
            distance = FindPlanet(planetStart, planetDest, distance, visitedPlanets, out bool found);
            if (!found)
                return -1;

            return distance;
        }

        public int FindPlanet(string planetStart, string planetDest, int distance, List<string> visitedPlanets, out bool found)
        {
            if (_planets[planetStart].Item1.Contains(planetDest) || _planets[planetStart].Item2.Contains(planetDest))
            {
                found = true;
                return distance - 1;
            }

            foreach (var planet in _planets[planetStart].Item1)
            {
                if (!visitedPlanets.Contains(planet))
                {
                    visitedPlanets.Add(planet);
                    var traveled = FindPlanet(planet, planetDest, distance + 1, visitedPlanets, out bool outFound);
                    if (outFound)
                    {
                        found = true;
                        return traveled;
                    }
                }
            }

            foreach (var planet in _planets[planetStart].Item2)
            {
                if (!visitedPlanets.Contains(planet))
                {
                    visitedPlanets.Add(planet);
                    var traveled = FindPlanet(planet, planetDest, distance + 1, visitedPlanets, out bool outFound);
                    if (outFound)
                    {
                        found = true;
                        return traveled;
                    }
                }
            }

            found = false;
            return -1;
        }

        public int CalculateTotalWeight()
        {
            var totalWeight = 0;

            var centralPoints = _planets.Keys.Where(x =>
            {
                return _planets[x].Item2.Count == 0;
            });
            foreach (var centralPoint in centralPoints)
            {
                totalWeight += GetPlanetDepth(centralPoint, 0);
            }
            return totalWeight;

        }

        private int GetPlanetDepth(string Planet, int level)
        {
            int weight = level;

            foreach (var planet in _planets[Planet].Item1)
            {
                weight += GetPlanetDepth(planet, level + 1);
            }
            return weight;
        }

    }
}
