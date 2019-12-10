using System;
using System.Text;
using Calendar.December06;
public class December06Puzzle : Calendar.PuzzleClass
{

    public December06Puzzle()
    {
        Title = "Universal Orbit Map";
    }
    public override string Run()
    {
        var contents = Tools.GetFileContents("dec6");
        var input = contents.Split("\r\n");
        var orbCalc = new OrbitCalculator();
        orbCalc.AddPlanets(input);
        var result = orbCalc.CalculateTotalWeight();

        var sb = new StringBuilder();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");


        result = orbCalc.ShortestPath("YOU", "SAN");

        sb.AppendLine($"\n\tPart 2: {result.ToString()}");

        return sb.ToString();
    }
}

namespace December06

{
}
