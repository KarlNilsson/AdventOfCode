using System;
using System.Collections.Generic;
using December02;
using System.Text;

public class December02Puzzle : Calendar.PuzzleClass
{
    public December02Puzzle()
    {
        Title = "1202 Program Alarm";
    }
    
    public override string Run()
    {
        var input = Tools.GetFileContents("dec2");
        var inputArray = Shifter.GetInputArray(input);
        var replacements = new Dictionary<int, int> { { 1, 12 }, { 2, 2 } };
        inputArray = Shifter.ReplaceValues(inputArray, replacements);
        var sb = new StringBuilder();
        var shifter = new Shifter(inputArray);
        var output = shifter.Alarm();
        sb.AppendLine($"\n\tPart 1: {output.ToString()}");

        inputArray = Shifter.GetInputArray(input);

        var output2 = shifter.FindVerbNouns(19690720, inputArray);
        var answer2 = output2.Key * 100 + output2.Value;
        sb.AppendLine($"\tPart 2: {answer2.ToString()}");

        return sb.ToString();
    }
}

namespace December02

{
}
