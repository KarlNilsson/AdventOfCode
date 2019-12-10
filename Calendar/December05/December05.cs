using System;
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
        shifter.PushInput(1);
        var result = shifter.ExecuteProgram();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");

        inputArray = IntcodeMachine.GetInputArray(input);
        shifter.LoadProgram(inputArray);
        shifter.PushInput(5);
        result = shifter.ExecuteProgram();
        sb.AppendLine($"\n\tPart 2: {result.ToString()}");

        return sb.ToString();
    }
}

namespace December05

{
}
