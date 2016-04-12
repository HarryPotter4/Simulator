using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model

    
{
    class M_Operators
    {
        int wReg = 0;
        int fileReg = 0;
        int destinationBit = 0;
        

        public void addWf(argument)
        {
            if (0==destinationBit)
                {
                    fileReg = wReg + fileReg;
                }
             else{
                wReg = wReg + fileReg;
            }               



        }

        public void andWf(argument)
        {
            if(0==destinationBit)
            {
                 
            }
        }
    }
}
