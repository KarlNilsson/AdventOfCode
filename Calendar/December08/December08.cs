using System;
using December08;
using System.Linq;
public class December08Puzzle : Calendar.PuzzleClass
{

    public December08Puzzle()
    {
        Title = "Space Image Format";
    }
    public override string Run()
    {
        var input = Tools.GetFileContents("dec8");

        var outputP1 = Part1(input);
        var outputP2 = ConstructOutputImage(input);
        sb.AppendLine($"\n\tPart 1: {outputP1.ToString()}");
        sb.AppendLine($"\n\tPart 2: {outputP2.ToString()}");
        return sb.ToString();
    }

    private string ConstructOutputImage(string input)
    {
        var image = new Image(input, 6, 25);
        var output = image.Draw();
        
        return output;
    }

    private int Part1(string input)
    {
        var image = new Image(input, 6, 25);
        Layer lowLayer = null;
        int i = 0;
        var zeroList = new int[image.Layers.Count];
        var minZeroes = int.MaxValue;
        foreach (var layer in image.Layers)
        {
            var currentZeroes = layer.RawData.Count(x => { return x == 0; });
            zeroList[i] = currentZeroes;
            if (currentZeroes < minZeroes)
            {
                minZeroes = currentZeroes;
                lowLayer = layer;
            }
            i++;
        }
        var outputP1 = lowLayer.RawData.Count(x => { return x == 1; }) * lowLayer.RawData.Count(x => { return x == 2; });

        return outputP1;
    }
}

namespace December08

{
}
