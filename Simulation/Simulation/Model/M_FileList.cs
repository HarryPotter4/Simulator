using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Model
{
    class M_FileList
    {
        private string[][] lineArgs;
        private int lineNumber = 0;

        /// <summary>
        /// Add argument 1 to object which is about program counter
        /// Add argument 2 to object which is about the operation with parameters.
        /// </summary>

        public M_FileList(string arg1, string arg2)
        {
            
            lineArgs[lineNumber][0] = arg1;
            lineArgs[lineNumber][1] = arg2;
            lineNumber++;

            MessageBox.Show(arg1 + " "+arg2);
        }
    }
}
