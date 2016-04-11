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

        /// <summary>
        /// Add argument 1 to object which is about program counter
        /// Add argument 2 to object which is about the operation with parameters.
        /// </summary>

        public M_FileListItem(string arg1, string arg2)
        {
            this.programCounter = arg1;
            this.opCode = arg2;
            MessageBox.Show(arg1 + " " + arg2);
        }
    }
}
