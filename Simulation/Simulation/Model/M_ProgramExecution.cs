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

            int byteOrientatedMask =  convertBinToInt("0010_0110_0000_0011");
            int bitOrientatedMask = convertBinToInt("0010_0110_0000_0011");
            int literalAndControl = convertBinToInt("0010_0110_0000_0011");

            if (code )
            {

            }
            else if( )

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
