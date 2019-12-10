using System;
using System.Collections.Generic;
using Intcode;

public class December02Puzzle : Calendar.PuzzleClass
{
    public December02Puzzle()
    {
        Title = "1202 Program Alarm";
    }
    
    public override string Run()
    {
        var input = Tools.GetFileContents("dec2");
        var inputArray = IntcodeMachine.GetInputArray(input);
        var replacements = new Dictionary<int, int> { { 1, 12 }, { 2, 2 } };
        inputArray = IntcodeMachine.ReplaceValues(inputArray, replacements);
        var intcode = new IntcodeMachine(inputArray);
        var output = intcode.Alarm();
        sb.AppendLine($"\n\tPart 1: {output.ToString()}");

        inputArray = IntcodeMachine.GetInputArray(input);

        var output2 = intcode.FindVerbNouns(19690720, inputArray);
        var answer2 = output2.Key * 100 + output2.Value;
        sb.AppendLine($"\tPart 2: {answer2.ToString()}");

        return sb.ToString();
    }
}

namespace December02

{
}
