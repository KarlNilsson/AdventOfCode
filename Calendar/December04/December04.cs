using Calendar.December04;
using System;
using System.Text;

public class December04Puzzle : Calendar.PuzzleClass
{
    public December04Puzzle()
    {
        Title = "Secure Container";
    }
    public override string Run()
    {
        var sb = new StringBuilder();
        var input = Tools.GetFileContents("dec4");
        var pwGen = new PasswordGenerator(input);
        var pwList = pwGen.GeneratePasswordList();
        var result = pwList.Count;
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");
        
        return sb.ToString();
    }
}

namespace December04

{
}
