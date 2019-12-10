using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Intcode
{
    public class IntcodeMachine
    {
        private enum OPCodeEnum
        {
            ADD = 1,
            MULT = 2,
            IN = 3,
            OUT = 4,
            JMP_T = 5,
            JMP_F = 6,
            LT = 7,
            EQ = 8,
            STOP = 99
        }

        private enum OPModeEnum
        {
            POS = 0,
            IMM = 1
        }

        private enum OPReturnCodeEnum
        {
            ERR = -1,
            OK = 0,
            STOP = 1,
            WAIT = 2
        }

        public enum MachineState
        {
            IDLE = 0,
            RUN = 1,
            WAIT = 2,
            STOP = 3
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
        private Queue<int> _inputStack;
        private Queue<int> _outputStack;
        int _inputReg;
        int _outputReg;
        public MachineState State { get; private set; }
        public IntcodeMachine(int[] Program = null)
        {
            _program = Program;
            _pc = 0;
            _instruction = new Instruction();
            _inputReg = 0;
            _outputReg = 0;
            _inputStack = new Queue<int>();
            _outputStack = new Queue<int>();
            State = MachineState.IDLE;
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
            _inputReg = 0;
            _outputReg = 0;
            State = MachineState.IDLE;
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


            OPReturnCodeEnum returnCode;

            switch (_instruction.OPCode)
            {
                case OPCodeEnum.STOP:
                    returnCode = Stop();
                    break;
                case OPCodeEnum.ADD:
                    returnCode = Add();
                    break;

                case OPCodeEnum.MULT:
                    returnCode = Mult();
                    break;

                case OPCodeEnum.IN:
                    returnCode = In();
                    break;

                case OPCodeEnum.OUT:
                    returnCode = Out();
                    break;

                case OPCodeEnum.JMP_T:
                    returnCode = Jmp_T();
                    break;

                case OPCodeEnum.JMP_F:
                    returnCode = Jmp_F();
                    break;

                case OPCodeEnum.LT:
                    returnCode = Lt();
                    break;

                case OPCodeEnum.EQ:
                    returnCode = Eq();
                    break;

                default:
                    Console.Error.WriteLine("Uncaught OP Code!");
                    returnCode = OPReturnCodeEnum.STOP;
                    break;

            }

            if (returnCode == OPReturnCodeEnum.ERR)
            {
                var e = new Exception($"Unexpected return code for instruction <{_instruction.OPCode}>");
                Console.Error.WriteLine(e.Message);
                throw e;
            }

            return returnCode;
        }

        public void QueueInput(int input)
        {
            _inputStack.Enqueue(input);
        }

        public int PeekInput(int input)
        {
            return _inputStack.Peek();
        }

        public int DequeueInput()
        {
            return _inputStack.Dequeue();
        }

        public void QueueOutput(int output)
        {
            _outputStack.Enqueue(output);
        }
        public int PeekOutput()
        {
            return _outputStack.Peek();
        }
        public int DequeueOutput()
        {
            return _outputStack.Dequeue();
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

        public int ExecuteProgram()
        {
            while (true)
            {
                State = MachineState.RUN;
                var returnValue = ExecuteNextInstruction();

                if (returnValue == OPReturnCodeEnum.STOP) { State = MachineState.STOP; break; }
                else if (returnValue == OPReturnCodeEnum.WAIT) { State = MachineState.WAIT; break; }

            }
            return _outputReg;
        }

        private OPReturnCodeEnum Add()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var reg3 = _program[_pc + 3];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _program[reg3] = value1 + value2;
            _pc += 4;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Mult()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var reg3 = _program[_pc + 3];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _program[reg3] = value1 * value2;
            _pc += 4;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum In()
        {
            var reg1 = _program[_pc + 1];
            if (_inputStack.Count < 1)
            {
                return OPReturnCodeEnum.WAIT;
            }
            _inputReg = _inputStack.Dequeue();
            _program[reg1] = _inputReg;
            _pc += 2;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Out()
        {
            var reg1 = _program[_pc + 1];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            _outputReg = value1;
            _outputStack.Enqueue(_outputReg);
            _pc += 2;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Jmp_T()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _pc = value1 != 0 ? value2 : _pc + 3;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Jmp_F()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _pc = value1 == 0 ? value2 : _pc + 3;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Lt()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var reg3 = _program[_pc + 3];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _program[reg3] = value1 < value2 ? 1 : 0;
            _pc += 4;
            return OPReturnCodeEnum.OK;
        }
        private OPReturnCodeEnum Eq()
        {
            var reg1 = _program[_pc + 1];
            var reg2 = _program[_pc + 2];
            var reg3 = _program[_pc + 3];
            var value1 = _instruction.Param1 == OPModeEnum.IMM ? reg1 : _program[reg1];
            var value2 = _instruction.Param2 == OPModeEnum.IMM ? reg2 : _program[reg2];
            _program[reg3] = value1 == value2 ? 1 : 0;
            _pc += 4;
            return OPReturnCodeEnum.OK;
        }

        private OPReturnCodeEnum Stop()
        {
            return OPReturnCodeEnum.STOP;
        }

    }
}