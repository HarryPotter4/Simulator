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
        
        

        public void addWf(int argument)
        {
            argument = fileReg;
            if (0==destinationBit)
                {
                    fileReg = wReg + fileReg;
                }
             else{
                wReg = wReg + fileReg;
            }               



        }

        public void andWf(int argument)
        {
            argument = fileReg;
            if(0==destinationBit)
            {
                fileReg = wReg && fileReg;     
            }
            else
            {
                wReg = wReg && fileReg;
            }
        }

        public void clearF(int argument)
        {
            argument = fileReg;
            fileReg = 0;
        }

        public void clearW()
        {
            wReg = 0;
        }

        public void compF(int argument)
        {
            argument = fileReg;
            fileReg=~fileReg;
        }

        

    }
}
