using System;
using System.Collections.Generic;
using System.Text;

namespace Intcode
{
    public static class IntcodeTests
    {
        private static string separator = new string('-', 80);
        public static string RunTests()
        {
            var sb = new StringBuilder();
            sb.Append(EQ_POS());
            sb.AppendLine(separator);

            sb.Append(LT_POS());
            sb.AppendLine(separator);

            sb.Append(EQ_IMM());
            sb.AppendLine(separator);

            sb.Append(LT_IMM());
            sb.AppendLine(separator);

            sb.Append(JMP_POS());
            sb.AppendLine(separator);

            sb.Append(JMP_IMM());
            sb.AppendLine(separator);

            sb.Append(DAY5_TEST());
            sb.AppendLine(separator);


            return sb.ToString();
        }

        private static string EQ_POS()
        {
            var inputArraySource = new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 8;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_POS: \tInput: {input}\tResult: {result}\tExpected: 1");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 9;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_POS: \tInput: {input}\tResult: {result}\tExpected: 0");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 7;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_POS: \tInput: {input}\tResult: {result}\tExpected: 0");

			return sb.ToString();
        }


        private static string LT_POS()
        {
            var inputArraySource = new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 7;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting LT_POS: \tInput: {input}\tResult: {result}\tExpected: 1");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 8;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting LT_POS: \tInput: {input}\tResult: {result}\tExpected: 0");
			return sb.ToString();
        }
        private static string EQ_IMM()
        {
            var inputArraySource = new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 8;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_IMM: \tInput: {input}\tResult: {result}\tExpected: 1");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 9;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_IMM: \tInput: {input}\tResult: {result}\tExpected: 0");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 7;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting EQ_IMM: \tInput: {input}\tResult: {result}\tExpected: 0");
            return sb.ToString();
        }

        private static string LT_IMM()
        {
            var inputArraySource = new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 7;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting LT_POS: \tInput: {input}\tResult: {result}\tExpected: 1");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 8;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting LT_POS: \tInput: {input}\tResult: {result}\tExpected: 0");
			return sb.ToString();
        }

        private static string JMP_POS()
        {
            var inputArraySource = new int[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 0;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting JMP_POS:\tInput: {input}\tResult: {result}\tExpected: 0");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);

            input = 1;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting JMP_POS:\tInput: {input}\tResult: {result}\tExpected: 1");
			return sb.ToString();
        }

        private static string JMP_IMM()
        {
            var inputArraySource = new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 0;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting JMP_IMM:\tInput: {input}\tResult: {result}\tExpected: 0");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 1;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting JMP_IMM:\tInput: {input}\tResult: {result}\tExpected: 1");
			return sb.ToString();
        }

        private static string DAY5_TEST()
        {
            var inputArraySource = new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
            var sb = new StringBuilder();
            var intcode = new IntcodeMachine();
            int input, result;

            var inputArray = new int[inputArraySource.Length];

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);

            input = -100;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting DAY5_PT2:\tInput: {input}\tResult: {result}\tExpected: 999");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 8;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting DAY5_PT2:\tInput: {input}\tResult: {result}\tExpected: 1000");

            Array.Copy(inputArraySource, 0, inputArray, 0, inputArraySource.Length);
            intcode.LoadProgram(inputArray);
            input = 100;
            intcode.QueueInput(input);
            result = intcode.ExecuteProgram();
            sb.AppendLine($"\tTesting DAY5_PT2:\tInput: {input}\tResult: {result}\tExpected: 1001");

			return sb.ToString();
        }
    }
}
