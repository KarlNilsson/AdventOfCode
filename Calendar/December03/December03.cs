using System;
using System.Collections.Generic;
using System.Text;
using Calendar.December03;

public class December03Puzzle : Calendar.PuzzleClass
{
    public December03Puzzle()
    {
        Title = "Crossed Wires";
    }
    public override string Run()
    {
        var contents = Tools.GetFileContents("dec3");
        var wireList = WireParser.Parse(contents);
        var circBoard = new CircuitBoard(wireList);
        var result = circBoard.CalculateManhattanDistance();
        var sb = new StringBuilder();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");

        result = circBoard.CalculateFewestSteps();
        sb.AppendLine($"\n\tPart 2: {result.ToString()}");

        return sb.ToString();
    }
}
