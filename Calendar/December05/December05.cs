using System;
using System.Text;
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
        var result = shifter.ThermalEnvironment(1);
        var sb = new StringBuilder();
        sb.AppendLine($"\n\tPart 1: {result.ToString()}");
        sb.AppendLine(new string('-', 50));

        var test1 = new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
        shifter.LoadProgram(test1);
        result = shifter.ThermalEnvironment(8);
        sb.AppendLine($"\tTest 1 (input == 8?): (input=8) {result.ToString()}");
        shifter.LoadProgram(test1);
        result = shifter.ThermalEnvironment(9);
        sb.AppendLine($"\tTest 1 (input == 8?): (input=9) {result.ToString()}");
        shifter.LoadProgram(test1);
        result = shifter.ThermalEnvironment(7);
        sb.AppendLine($"\tTest 1 (input == 8?): (input=7) {result.ToString()}");

        var test2 = new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test2);
        result = shifter.ThermalEnvironment(7);
        sb.AppendLine($"\tTest 2 (input < 8)?: (input=7) {result.ToString()}");
        shifter.LoadProgram(test2);
        result = shifter.ThermalEnvironment(8);
        sb.AppendLine($"\tTest 2 (input < 8)?: (input=8) {result.ToString()}");

        var test3 = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test3);
        result = shifter.ThermalEnvironment(8);
        sb.AppendLine($"\tTest 3 (input == 8)?: (input=8) {result.ToString()}");
        test3 = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
        shifter.LoadProgram(test3);
        result = shifter.ThermalEnvironment(9);
        sb.AppendLine($"\tTest 3 (input == 8)?: (input=9) {result.ToString()}");
        test3 = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
        shifter.LoadProgram(test3);
        result = shifter.ThermalEnvironment(7);
        sb.AppendLine($"\tTest 3 (input == 8)?: (input=7) {result.ToString()}");

        var test4 = new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test4);
        result = shifter.ThermalEnvironment(7);
        sb.AppendLine($"\tTest 4 (input < 8)?: (input=7) {result.ToString()}");
        test4 = new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
        shifter.LoadProgram(test4);
        result = shifter.ThermalEnvironment(8);
        sb.AppendLine($"\tTest 4 (input < 8)?: (input=8) {result.ToString()}");


        var test5 = new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test5);
        result = shifter.ThermalEnvironment(0);
        sb.AppendLine($"\tTest 5 (input == 0)?: (input=0) {result.ToString()}");
        test5 = new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        shifter.LoadProgram(test5);
        result = shifter.ThermalEnvironment(100);
        sb.AppendLine($"\tTest 5 (input == 0)?: (input=100) {result.ToString()}");
        test5 = new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
        shifter.LoadProgram(test5);
        result = shifter.ThermalEnvironment(-100);
        sb.AppendLine($"\tTest 5 (input == 0)?: (input=-100) {result.ToString()}");

        var test6 = new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test6);
        result = shifter.ThermalEnvironment(0);
        sb.AppendLine($"\tTest 6 (input == 0)?: (input=0) {result.ToString()}");
        test6 = new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
        shifter.LoadProgram(test6);
        result = shifter.ThermalEnvironment(100);
        sb.AppendLine($"\tTest 6 (input == 0)?: (input=100) {result.ToString()}");
        test6 = new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
        shifter.LoadProgram(test6);
        result = shifter.ThermalEnvironment(-100);
        sb.AppendLine($"\tTest 6 (input == 0)?: (input=-100) {result.ToString()}");

        var test7 = new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
        sb.AppendLine(new string('-', 50));
        shifter.LoadProgram(test7);
        result = shifter.ThermalEnvironment(8);
        sb.AppendLine($"\tTest 6 (input == 8)?: (input=8) {result.ToString()}");
        test7 = new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
        shifter.LoadProgram(test7);
        result = shifter.ThermalEnvironment(9);
        sb.AppendLine($"\tTest 6 (input == 8)?: (input=9) {result.ToString()}");
        test7 = new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
        shifter.LoadProgram(test7);
        result = shifter.ThermalEnvironment(-9);
        sb.AppendLine($"\tTest 6 (input == 8)?: (input=-9) {result.ToString()}");



        inputArray = IntcodeMachine.GetInputArray(input);
        shifter.LoadProgram(inputArray);
        result = shifter.ThermalEnvironment(5);
        sb.AppendLine($"\n\tPart 2: {result.ToString()}");

        return sb.ToString();
    }
}

namespace December05

{
}
