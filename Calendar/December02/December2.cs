using System;
using System.Collections.Generic;
using December02;
using System.Text;

public class December2Puzzle : Calendar.Puzzle
{
    public string Run()
    {
        var input = Shifter.GetInputArray($"{Tools.RootPath}/resources/dec2/dec2.txt");
        var replacements = new Dictionary<int, int> { { 1, 12 }, { 2, 2 } };
        input = Shifter.ReplaceValues(input, replacements);
        var sb = new StringBuilder();
        var output = Shifter.Shift(input);
        sb.AppendLine($"\n\tPart 1: {output.ToString()}");

        input = Shifter.GetInputArray($"{Tools.RootPath}/resources/dec2/dec2.txt");

        var output2 = Shifter.FindVerbNouns(19690720, input);
        var answer2 = output2.Key * 100 + output2.Value;
        sb.AppendLine($"\tPart 2: {answer2.ToString()}");

        return sb.ToString();
    }
}

namespace December2
{
}
