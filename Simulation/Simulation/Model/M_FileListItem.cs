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
        private string sourceCode;

        public string SourceCode
        {
            get
            {
                return sourceCode;
            }
            set
            {
                sourceCode = value;
            }
        }
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

        public M_FileListItem(string arg1, string arg2, string sourceCode) 
        {
            this.SourceCode = sourceCode;
            this.ProgramCounter = arg1;
            this.OpCode = arg2;
        }
    }
}
