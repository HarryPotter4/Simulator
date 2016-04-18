using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.ViewModels;

namespace Simulation.Model
{
    class M_ProgramExecution
    {
        private List<M_FileListItem> _listItems;
        private M_Operators command;
        private RamViewModel ramViewModel;
        


      
        public M_ProgramExecution(List<M_FileListItem> _listItems, RamViewModel ramViewModel) 
        {
            this.ramViewModel = ramViewModel;
            this._listItems = _listItems;
            command = new M_Operators(ramViewModel);
            if (this._listItems.Count != 0)
            {
                startProgram();
            }
            
        }

        private void startProgram()
        {
            foreach(M_FileListItem listItem in _listItems)
            {
                nextMachineCycle(listItem.ProgramCounter, listItem.OpCode);
            }
        }

        private void nextMachineCycle(string programCounter, string opCode)
        {
            findOperation(opCode);
        }

        private void findOperation(string opCode)
        {
            int code = Convert.ToInt32(opCode);

            int byteOrientatedMask =  convertBinToInt("1111_0000_0000_0000");
            int bitOrientatedMask = convertBinToInt("0001_0000_0000_0000");
            int literalAndControl = convertBinToInt("0010_0000_0000_0000");

            byteOrientatedMask = (code & byteOrientatedMask) / Convert.ToInt32(Math.Pow(2,12));
            bitOrientatedMask = (code & bitOrientatedMask) / Convert.ToInt32(Math.Pow(2, 12));
            literalAndControl = (code & literalAndControl) / Convert.ToInt32(Math.Pow(2, 12));

            if (byteOrientatedMask == 0)
            {
                select_BO_Command(code);
            }
            else if(literalAndControl > 1)
            {
                select_LIT_Operations(code);
            }
            else if(bitOrientatedMask == 1)
            {
                select_Bit_Operations(code);
            }

        }

        private void select_BO_Command(int opCode)
        {
            int code = Convert.ToInt32(opCode);

            int operationCodeMask = convertBinToInt("0000_1111_0000_0000");
            int destinationBitMask = convertBinToInt("0000_0000_1000_0000");
            int fileRegisterMask = convertBinToInt("0010_0000_0111_1111");

            int operationCode = (code & operationCodeMask) / Convert.ToInt32(Math.Pow(2, 8));
            int destinationsBit = (code & destinationBitMask) / Convert.ToInt32(Math.Pow(2, 7));
            int fileRegister = (code & fileRegisterMask) / Convert.ToInt32(Math.Pow(2, 12));

            switch (operationCode)
            {
                case 0:
                    specialCases(fileRegister);
                    break;
                case 1:
                    if (destinationsBit == 0)
                        command.clearW();
                    else if (destinationsBit == 1)
                        command.clearF(fileRegister);
                    else
                        Console.WriteLine("Case1 of CLRW/F");
                    break;

                case 2:
                    command.subwf(destinationsBit, fileRegister);
                    break;

                case 3:
                    command.decf(destinationsBit, fileRegister);
                    break;

                case 4:
                    command.iOrWf(destinationsBit, fileRegister);
                    break;

                case 2:
                    break;

                default:
                    break;
            }
  

            throw new NotImplementedException();
        }

        private void specialCases(int fileRegister)
        {
            throw new NotImplementedException();
        }

        private void select_LIT_Operations(int code)
        {
            throw new NotImplementedException();
        }

        private void select_Bit_Operations(int code)
        {
            throw new NotImplementedException();
        }

        private int convertBinToInt(string bin)
        {
            bin = bin.Replace("_", "");

            return Convert.ToInt32(bin, 2);
        }

        private void getOperation()
        {

        }

        private void getArgument()
        {

        }
        private void getDestinationBit()
        {

        }


    }
}
