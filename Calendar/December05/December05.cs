using System;
using System.Text;
using Intcode;
public class December05Puzzle : Calendar.PuzzleClass
{

    public December05Puzzle()
    {
        Title = "Sunny with a Chance of Asteroids";
    }

    public override string Run()
    {
        var input = Tools.GetFileContents("dec5");
        var inputArray = IntcodeMachine.GetInputArray(input);
        var shifter = new IntcodeMachine(inputArray);
        var result = shifter.ThermalEnvironment(1);
        var sb = new StringBuilder();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");

        inputArray = IntcodeMachine.GetInputArray(input);
        shifter.LoadProgram(inputArray);
        result = shifter.ThermalEnvironment(5);
        sb.AppendLine($"\n\tPart 2: {result.ToString()}");

        return sb.ToString();
    }
}

namespace December05

{
}
