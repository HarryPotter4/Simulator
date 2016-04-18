using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    class ProgramExecution
    {
        private List<M_FileListItem> _listItems;
        private M_Operators command;

        public ProgramExecution(List<M_FileListItem> _listItems)
        {
            this._listItems = _listItems;

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
            throw new NotImplementedException();
        }
    }
}
