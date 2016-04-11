using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    class M_FileHandler : PropertyChangedBase
    {
        private string fileName;

        public M_FileHandler(){
                       
        }
        public string Name{
            get { return fileName; }
            set {  fileName = value; }
        }
    }
}
