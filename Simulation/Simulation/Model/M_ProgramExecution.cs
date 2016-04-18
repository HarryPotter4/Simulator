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
            


        }
    }
}
