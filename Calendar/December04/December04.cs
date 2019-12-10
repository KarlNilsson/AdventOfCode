using Calendar.December04;
using System;

public class December04Puzzle : Calendar.PuzzleClass
{
    public December04Puzzle()
    {
        Title = "Secure Container";
    }
    public override string Run()
    {
        var input = Tools.GetFileContents("dec4");
        var pwGen = new PasswordGenerator(input);
        var pwList = pwGen.GeneratePasswordList();
        var result = pwList.Count;
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");

        pwList = pwGen.GeneratePasswordList(false);
        result = pwList.Count;
        sb.AppendLine($"\n\tPart 2: {result.ToString()}");
        
        return sb.ToString();
    }
}

namespace December04

{
}
