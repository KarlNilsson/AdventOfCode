using System;
using System.Collections.Generic;
using System.Text;

namespace December02
{
    public static class Shifter
    {
        private enum OPCodeEnum
        {
            ADD = 1,
            MULT = 2,
            STOP = 99
        }
        public static int[] GetInputArray(string Filepath)
        {
            var contents = System.IO.File.ReadAllText(Filepath).Split(',');
            var contentsAsInt = Array.ConvertAll(contents, int.Parse);
            return contentsAsInt;
        }

        public static int[] ReplaceValues(int[] InputArray, Dictionary<int, int> Replacements)
        {
            foreach (var kvPair in Replacements)
            {
                InputArray[kvPair.Key] = kvPair.Value;
            }
            var returnArray = new int[InputArray.Length];
            Array.Copy(InputArray, 0, returnArray, 0, InputArray.Length);
            return returnArray;
        }

        internal static KeyValuePair<int, int> FindVerbNouns(int Target, int[] InputArray)
        {
            KeyValuePair<int, int> resultPair;
            for (var verb = 1; verb < 100; verb++)
            {
                for (var noun = 1; noun < 100; noun++)
                {

                    var replacement = new Dictionary<int, int> { { 1, verb }, { 2, noun } };
                    var tempInput = ReplaceValues(InputArray, replacement);
                    int result = Shift(tempInput);

                    if (result == Target)
                    {
                        resultPair = new KeyValuePair<int, int>(verb, noun);
                        return resultPair;
                    }
                }
            }
            return new KeyValuePair<int, int>(-1, -1);


        }

        public static int Shift(int[] InputArray)
        {
            OPCodeEnum currentOP;
            var currentPosition = 0;
            for (; ; currentPosition += 4)
            {
                currentOP = (OPCodeEnum)InputArray[currentPosition];
                if (currentOP == OPCodeEnum.STOP)
                {
                    break;
                }
                var source1 = InputArray[currentPosition + 1];
                var source2 = InputArray[currentPosition + 2];
                var destination = InputArray[currentPosition + 3];
                if (currentOP == OPCodeEnum.ADD)
                {
                    InputArray[destination] = InputArray[source1] + InputArray[source2];
                }
                else if (currentOP == OPCodeEnum.MULT)
                {
                    InputArray[destination] = InputArray[source1] * InputArray[source2];
                }
            }
            return InputArray[0];
        }

    }
}
