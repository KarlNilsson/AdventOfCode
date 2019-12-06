using System;
using System.Text;
using December02;
public class December05Puzzle : Calendar.PuzzleClass
{

    public December05Puzzle()
    {
        Title = "Sunny with a Chance of Asteroids";
    }

    public override string Run()
    {
        var input = Tools.GetFileContents("dec5");
        var inputArray = Shifter.GetInputArray(input);
        var shifter = new Shifter(inputArray);
        var result = shifter.ThermalEnvironment(1);
        var sb = new StringBuilder();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");
        return sb.ToString();
    }
}

namespace December05

{
}
