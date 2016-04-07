using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    public class File
    {
        public string filePath { get; set; }

        public static File createfilePath()
        {
            return new File { filePath = "Franz"};
        }
    }
}
