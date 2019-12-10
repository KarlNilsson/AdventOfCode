using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        var input = Tools.GetFileContents("dec7");
        var defaultProgram = IntcodeMachine.GetInputArray(input);

        var thrusterSeqsP1 = generateAllPermutations(new List<int> { 0, 1, 2, 3, 4 });
        var thrusterSeqsP2 = generateAllPermutations(new List<int> { 5, 6, 7, 8, 9 });

        var outputP1 = RunAmplifiers(thrusterSeqsP1, (int[])defaultProgram.Clone());
        var outputP2 = RunAmplifiers(thrusterSeqsP2, (int[])defaultProgram.Clone());

        sb.AppendLine($"\n\tPart 1: {outputP1.ToString()}");
        sb.AppendLine($"\n\tPart 2: {outputP2.ToString()}");
        return sb.ToString();
    }

    private int RunAmplifiers(List<List<int>> permutations, int[] program)
    {
        var numAmplifiers = 5;
        var amplifiers = new List<IntcodeMachine>(numAmplifiers);
        for (int i = 0; i < numAmplifiers; i++)
        {
            amplifiers.Add(new IntcodeMachine());
        }

        var thrusterSeqs = permutations;

        var maxOutput = int.MinValue;
        foreach (var thrusterSeq in thrusterSeqs)
        {
            var machineStates = new IntcodeMachine.MachineState[numAmplifiers];
            Debug.Assert(thrusterSeq.Count == numAmplifiers);
            Debug.Assert(machineStates.Length == numAmplifiers);

            // Reload the base program for each thruster permutation
            for (int i = 0; i < numAmplifiers; i++)
            {
                var programClone = (int[])program.Clone();
                amplifiers[i].LoadProgram(programClone);
                machineStates[i] = amplifiers[i].State;
                amplifiers[i].QueueInput(thrusterSeq[i]);

            }

            // Default output is 0;
            var currentOutput = 0;
            while (machineStates.All(x => x != IntcodeMachine.MachineState.STOP))
            {

                for (int i = 0; i < amplifiers.Count; i++)
                {
                    var currentMachine = amplifiers[i];
                    var phaseSetting = thrusterSeq[i];
                    currentMachine.QueueInput(currentOutput);
                    currentMachine.ExecuteProgram();
                    currentOutput = currentMachine.DequeueOutput();
                    machineStates[i] = currentMachine.State;
                }
                maxOutput = currentOutput > maxOutput ? currentOutput : maxOutput;
            }
        }
        return maxOutput;
    }

    private List<List<int>> generateAllPermutations(List<int> items)
    {
        var allPerms = new List<List<int>>();
        int[] currentPerm = new int[items.Count];
        bool[] inSelection = new bool[items.Count];
        GeneratePermutation(items, inSelection, currentPerm, allPerms, 0);
        return allPerms;
    }

    private void GeneratePermutation(List<int> items, bool[] inSelection, int[] currentPerm, List<List<int>> allPerms, int nextPos)
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
                    GeneratePermutation(items, inSelection, currentPerm, allPerms, nextPos + 1);
                    inSelection[i] = false;
                }
            }
        }

    }
}

namespace December07

{
}
