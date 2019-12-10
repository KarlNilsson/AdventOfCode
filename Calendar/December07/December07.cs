using System;
using System.Collections.Generic;
using System.Linq;
using Intcode;

public class December07Puzzle : Calendar.PuzzleClass
{
    public December07Puzzle()
    {
        Title = "Amplification Circuit";
    }

    public override string Run()
    {
        var thrusterSeqs = generateAllPermutations(new List<int> { 0, 1, 2, 3, 4 });
        var maxOutput = int.MinValue;
        var input = Tools.GetFileContents("dec7");
        var defaultProgram = IntcodeMachine.GetInputArray(input);
        var intcode = new IntcodeMachine();
        var programCopy = new int[defaultProgram.Length];
        Array.Copy(defaultProgram, 0, programCopy, 0, defaultProgram.Length);
        intcode.LoadProgram(programCopy);



        foreach (var thrusterSeq in thrusterSeqs)
        {
            intcode.PushOutput(0);
            foreach(var phaseSetting in thrusterSeq)
            {
                intcode.PushInput(intcode.PopOutput());
                intcode.PushInput(phaseSetting);
                Array.Copy(defaultProgram, 0, programCopy, 0, defaultProgram.Length);
                intcode.LoadProgram(programCopy);
                intcode.ExecuteProgram();
            }
            var currentOutput = intcode.PopOutput();
            maxOutput = currentOutput > maxOutput ? currentOutput : maxOutput;

        }

        sb.AppendLine($"\n\tPart 1: {maxOutput.ToString()}");

        sb.AppendLine($"\n\tPart 2: {maxOutput.ToString()}");
        return sb.ToString();
    }

    private List<List<int>> generateAllPermutations(List<int> items)
    {
        var allPerms = new List<List<int>>();
        int[] currentPerm = new int[items.Count];
        bool[] inSelection = new bool[items.Count];
        generatePermutation(items, inSelection, currentPerm, allPerms, 0);
        return allPerms;
    }

    private void generatePermutation(List<int> items, bool[] inSelection, int[] currentPerm, List<List<int>> allPerms, int nextPos)
    {
        if (nextPos == items.Count)
        {
            allPerms.Add(currentPerm.ToList());
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!inSelection[i])
                {
                    inSelection[i] = true;
                    currentPerm[nextPos] = items[i];
                    generatePermutation(items, inSelection, currentPerm, allPerms, nextPos + 1);
                    inSelection[i] = false;
                }
            }
        }

    }

}

namespace December07

{
}
