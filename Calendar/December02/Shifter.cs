using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace December02
{
    public class Shifter
    {
        private enum OPCodeEnum
        {
            ADD = 1,
            MULT = 2,
            IN = 3,
            OUT = 4,
            STOP = 99
        }

        private enum OPModeEnum
        {
            POS = 0,
            IMM = 1
        }

        private enum OPReturnCodeEnum
        {
            STOP = -1,
            OK = 0
        }

        private struct Instruction
        {
            public OPCodeEnum OPCode;
            public OPModeEnum Param1;
            public OPModeEnum Param2;
            public OPModeEnum Param3;
        }

        private int[] _program;
        private int _pc;
        private Instruction _instruction;
        int _inputReg;
        int _outputReg;
        public Shifter(int[] Program = null)
        {
            _program = Program;
            _pc = 0;
            _instruction = new Instruction();
            _inputReg = 0;
            _outputReg = 0;
        }

        public static int[] GetInputArray(string Input)
        {
            var contents = Input.Split(',');
            var contentsAsInt = Array.ConvertAll(contents, int.Parse);
            return contentsAsInt;
        }
        public void LoadProgram(int[] Program)
        {
            _program = Program;
            _pc = 0;
        }

        public int ExecuteProgram()
        {
            return -1;
        }

        private void Output(int OutputCode)
        {
            Console.WriteLine(OutputCode);
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

        public KeyValuePair<int, int> FindVerbNouns(int Target, int[] InputArray)
        {
            KeyValuePair<int, int> resultPair;
            for (var verb = 1; verb < 100; verb++)
            {
                for (var noun = 1; noun < 100; noun++)
                {

                    var replacement = new Dictionary<int, int> { { 1, verb }, { 2, noun } };
                    var tempInput = ReplaceValues(InputArray, replacement);
                    LoadProgram(tempInput);
                    int result = Alarm();

                    if (result == Target)
                    {
                        resultPair = new KeyValuePair<int, int>(verb, noun);
                        return resultPair;
                    }
                }
            }
            return new KeyValuePair<int, int>(-1, -1);


        }

        // Returns a Tuple, where the first item is the return value,
        // and the second the number of steps to increase the program counter.
        private OPReturnCodeEnum ExecuteNextInstruction()
        {
            _instruction.OPCode = (OPCodeEnum)(_program[_pc] % 100);
            _instruction.Param1 = (OPModeEnum)(_program[_pc] / 100 % 10);
            _instruction.Param2 = (OPModeEnum)(_program[_pc] / 1000 % 10);
            _instruction.Param3 = (OPModeEnum)(_program[_pc] / 10000 % 10);


            var returnCode = OPReturnCodeEnum.STOP;
            var pcIncrease = -1;

            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var reg3 = _program[_pc + 3];
            int value1, value2;
            switch (_instruction.OPCode)
            {
                case OPCodeEnum.STOP:
                    returnCode = OPReturnCodeEnum.STOP;
                    pcIncrease = -1;
                    break;

                case OPCodeEnum.ADD:
                    value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
                    value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
                    _program[reg3] = value1 + value2;
                    _pc += 4;
                    returnCode = OPReturnCodeEnum.OK;
                    break;

                case OPCodeEnum.MULT:
                    value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
                    value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
                    _program[reg3] = value1 * value2;
                    _pc += 4;
                    returnCode = OPReturnCodeEnum.OK;
                    break;

                case OPCodeEnum.IN:
                    _program[reg1] = _inputReg;
                    _pc += 2;
                    returnCode = OPReturnCodeEnum.OK;
                    break;

                case OPCodeEnum.OUT:
                    value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
                    _outputReg = value1;
                    Console.WriteLine(_outputReg);
                    _pc += 2;
                    returnCode = OPReturnCodeEnum.OK;
                    break;

                default:
                    returnCode = OPReturnCodeEnum.STOP;
                    pcIncrease = -1;
                    break;

            }

            return returnCode;
        }

        public int Alarm()
        {
            while (true)
            {
                var returnValue = ExecuteNextInstruction();
                if (returnValue == OPReturnCodeEnum.STOP)
                {
                    break;
                }
            }
            return _program[0];
        }

        public int ThermalEnvironment(int input)
        {
            _inputReg = input;
            while (true)
            {
                var returnValue = ExecuteNextInstruction();
                if (returnValue == OPReturnCodeEnum.STOP)
                {
                    break;
                }
            }
            return _outputReg;
        }

    }
}