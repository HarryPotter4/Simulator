using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Model
{
    class M_FileListItem
    {
        private string programCounter;
        private string opCode;

        public string ProgramCounter
        {
            get
            {
                return programCounter;
            }

            set
            {
                programCounter = value;
            }
        }

        public string OpCode
        {
            get
            {
                return opCode;
            }

            set
            {
                opCode = value;
            }
        }

        /// <summary>
        /// Add argument 1 to object which is about program counter
        /// Add argument 2 to object which is about the operation with parameters.
        /// </summary>

        public M_FileListItem(string arg1, string arg2)
        {
            this.ProgramCounter = arg1;
            this.OpCode = arg2;            
        }
    }
}
