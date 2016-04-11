using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulation.ViewModels
{

    class VM_FileHandler
    {
        private StreamReader file;

        public VM_FileHandler(StreamReader file)
        {
            this.file = file;

            Regex rgx = new Regex(@"^[0-9]\d{4} ^[0-9]\d{4}$");
            foreach (string partNumber in partNumbers)
                Console.WriteLine("{0} {1} a valid part number.",
                                  partNumber,
                                  rgx.IsMatch(partNumber) ? "is" : "is not");
        }


            while(file.EndOfStream)
            {
                string line = file.ReadLine()
                if()
                line.Split(' ', '');

                new VM_FileList(ArgIterator,)
            }


        }
        
    }
}
